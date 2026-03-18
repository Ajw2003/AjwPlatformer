using TMPro;
using UnityEngine;
using System.Collections;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private Rigidbody2D _rb;

    public int health = 30;
   
    public TMP_Text healthText;

    public bool isGrounded = true;

    public bool hasEnergy = true;
    
    public float speed = 10;

    public float mSpeed = 1;
    
    public float m_vspeed = 1;

    public float vspeed = 500;

    public float dashSpeed = 25f;

    public bool faceR = true;

    public int coinCounter = 0;

    public Vector2 mov;

    public int n;
    
    private Vector2 dashingDir;
    private bool isDashing;
    private TrailRenderer trailRenderer;

    public TMP_Text coinText;

    private SpriteRenderer _spr_rend;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X) && hasEnergy)
        {
            isDashing = true;
            hasEnergy = false;
            trailRenderer.emitting = true;
            var x = Input.GetAxisRaw("Horizontal");
            var y = Input.GetAxisRaw("Vertical");
            dashingDir = new Vector2(x, y).normalized;
            if (dashingDir == Vector2.zero)
            {
                dashingDir = new Vector2(transform.localScale.x, 0f);
            }
            StartCoroutine(StopDashing());
        }
        

        if (isDashing)
        {
            _rb.linearVelocity = dashingDir.normalized * dashSpeed;
            return;
        }

        
        if (Input.GetKeyDown(KeyCode.Z) && isGrounded)
        {
            Debug.Log("Move up");
            _rb.AddForce(Vector2.up * vspeed);
            isGrounded = false;
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            _rb.AddForce(Vector2.right * (speed * mSpeed));
            mov = Vector2.right;
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            _rb.AddForce(Vector2.left * (speed * m_vspeed));
            mov = Vector2.left;
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            _rb.AddForce(Vector2.down * (speed * mSpeed));
            mov = Vector2.down;
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            mov = Vector2.up;
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        isGrounded = true;
        hasEnergy = true;
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        isGrounded = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<CollectableObj>())
        {
            coinCounter++;
            
        }

        if (other.GetComponent<EnemyObj>())
        {
            health = health - 10;
        }
        coinText.text = "Coins Collected: " + coinCounter.ToString();
        healthText.text = "Total Health:" + health.ToString();

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }
    }
    private IEnumerator StopDashing()
    {
        yield return new WaitForSeconds(0.5f);
        trailRenderer.emitting = false;
        isDashing = false;
    }

}
