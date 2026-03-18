using UnityEngine;

public class ShootGun : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        ;
        // movement
            // if the D button is pressed. then for as long as it s pressed
                //apply left.10 force to mario 
            // if the A button is pressed. then for as long as it s pressed
                //apply right.10 force to mario
            // if the W button is pressed. then do one time
                //apply up.50 force to mario 
        
        // damage
            // event.mario contacts enemy
            
                //if angle of contact with its origin on the Y axis > 45 then
                
                    // delete the enemy that was contacted
                    //apply up.30 force to mario
                    // give 30 points to player
                    
                // else if mario has star 
                
                    // delete the enemy that was contacted
                    // give 30 points to player
                    
                // else 
                    
                    //get the size of mario
                    //decrease 1 from his size
                    //if size = 0 then
                    
                        // kill player()
                        
        //finish level
            
            //if event.mario contacts object
            
                // if the contacted object is a flag pole then
                    
                    // while player not touch ground do
                    
                        // points earned ++
        
                    // give "points earned" as escore to player
        
                    //control mario to castle 
                    // wait 2 sec
                    // load "next stage"
                    
            
            

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
