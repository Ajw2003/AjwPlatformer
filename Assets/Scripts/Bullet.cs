using UnityEngine;

public class Bullet : MonoBehaviour
{
    public Vector2 lastDirection;
    public float bulletVelocity = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (lastDirection != Vector2.zero)
        {
            transform.Translate(lastDirection * (bulletVelocity * Time.deltaTime));
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
