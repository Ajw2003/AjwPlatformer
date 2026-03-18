using UnityEngine;

public class PowerUpSpawner : MonoBehaviour
{
    private bool used;

    public GameObject[] powerup;
    public Transform spawnPoint;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        int randomPowerup = Random.Range(0, powerup.Length);
        GameObject power = Instantiate(powerup[randomPowerup], transform.position, transform.rotation);
        Debug.Log(randomPowerup);
    }
}
