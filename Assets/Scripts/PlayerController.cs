using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D rb; // reference / phone number for the rigidbody attached to the player 
    
    private Vector2 lastDirection; // the last direction the player moved stored as a vector2

    public float speed; // amount of force to exert on player when moving
    
    public float jumpForce =250; // amount of force to exert on player when jumping

    public bool Grounded = true; //bool to check if character is on ground and can jump

    public TMP_Text coinText; // reference i.e. phone number for coin text, must assign in inspector
    
    public TMP_Text healthText; // reference i.e. phone number for health text, must assign in inspector

    public int coinsCollected = 0; //coins collected value

    public int currentHealth;//curent health value
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();// find the rigid body and assign it
        healthText.text = currentHealth.ToString(); // set the health text to 0
        coinText.text = coinsCollected.ToString(); // set the coin text to 0
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && Grounded)// if space is pressed and player is on ground then jump
        {
            rb.AddForce(Vector2.up * jumpForce);// add force in the up direction and multiply it by the jump force value
            Grounded = false;// set grounded to false now that character is in air
        }

        if (Input.GetKey(KeyCode.A))// if A is pressed move left
        {
            lastDirection = Vector2.left;// set the last direction moved to left
            rb.AddForce(Vector2.left * speed); // add force in the left direction and multiply by speed value
            
        }

        if (Input.GetKey(KeyCode.D)) // if D is pressed move Right
        {
            lastDirection = Vector2.right;// set the last direction moved to right
            rb.AddForce(Vector2.right * speed);// add force in the left direction and multiply by speed value
        }

        if (Input.GetKey(KeyCode.LeftShift))// if shift pressed 
        {
            rb.AddForce(lastDirection * jumpForce / 10);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)// when colliding with the ground run code bellow
    {
        Grounded = true;// set grounded to true when character touches ground 
    }

    private void OnTriggerEnter2D(Collider2D other)// when colliding with objects that have their "Is trigger" toggled to on. run this code
    {
        if (other.GetComponent<Collectable>())// check to see if object collided with is a collectable then run code bellow if true
        {
            coinsCollected++;// increase coins collected by 1
            coinText.text = coinsCollected.ToString();// set the text which shows the coins collected to the number of coins collected
        }
        else if (other.GetComponent<Hazard>())// check to see if object collided with is a hazard then run code bellow if true
        {
            currentHealth--; // decrease health by 1
            healthText.text = currentHealth.ToString();// set the text which displays current health to the amount of currentHealth
            if (currentHealth <= 0)// check to see if health is at or bellow zero then run code bellow if true
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);// get the name of the current scene being used then reload it / respawn the player and objects
            }
        }
        else if (other.GetComponent<Goall>())// check to see if the object collided with is a goal then run the code bellow if true
        {
            SceneManager.LoadScene(other.GetComponent<Goall>().NextLevel);// get the name of the next level from the goal and open it transporting the player to that level
        }
        else if (other.GetComponent<MushroomUp>())
        {
            currentHealth++; // / increase health by 1
            healthText.text = currentHealth.ToString();
        }
    }
}
