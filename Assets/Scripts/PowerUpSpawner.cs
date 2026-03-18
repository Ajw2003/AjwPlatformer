using UnityEngine;
using Random = UnityEngine.Random;
public class PowerUpSpawner : MonoBehaviour

{
    private bool used;
    public GameObject[] powerUp;//the list of power ups
    public Transform spawnPoint;//et point in space to spawn 
    public int[] arrayOfInt;
    public float[] arrayOfFloat;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void OnCollisionEnter2D(Collision2D other)
    {
        //
        int randomPowerUp = Random.Range(0, powerUp.Length);// get a ramdom obj. in 
        GameObject power = Instantiate(powerUp[randomPowerUp], spawnPoint.position, transform.rotation);

        int currentNumber = arrayOfInt[1];
        float currentFloat = arrayOfFloat[3];
        Debug.Log(randomPowerUp);
    }
}
// putting [] after a type for function makes n eray(list)