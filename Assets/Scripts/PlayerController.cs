using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb;
    
    private Vector2 lastDirection;

    public float speed;
    
    public float jumpForce =250;

    public bool Grounded = true;

    public TMP_Text coinText;
    
    public TMP_Text healthText;

    public int coinsCollected = 0;

    public int currentHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        healthText.text = currentHealth.ToString();
        coinText.text = coinsCollected.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Grounded)
        {
            rb.AddForce(Vector2.up * jumpForce);
            Grounded = false;
        }

        if (Input.GetKey(KeyCode.A))
        {
            lastDirection = Vector2.left;
            rb.AddForce(Vector2.left * speed);
            
        }

        if (Input.GetKey(KeyCode.D))
        {
            lastDirection = Vector2.right;
            rb.AddForce(Vector2.right * speed);
        }

        if (Input.GetKey(KeyCode.LeftShift))
        {
            rb.AddForce(lastDirection * jumpForce / 10);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        Grounded = true;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponent<Collectable>())
        {
            coinsCollected++;
            coinText.text = coinsCollected.ToString();
        }
        else if (other.GetComponent<Hazard>())
        {
            currentHealth--;
            healthText.text = currentHealth.ToString();
            if (currentHealth <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                SceneManager.LoadScene("SampleScene");
            }
        }
        else if (other.GetComponent<Goall>())
        {
            SceneManager.LoadScene(other.GetComponent<Goall>().NextLevel);
        }
    }
}
