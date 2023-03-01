using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierMovement : MonoBehaviour
{
    Rigidbody2D rb;
    
    public static bool touch = false;
    public static bool attackAnim = false;
    public static bool isWalk = false;
    public static bool isAttack = false;
    private float positionY;
    
    
    

    
    
     public Transform player;//set target from inspector instead of looking in Update
    
     public float speed = 3f;
     void Start()
     {
        rb = GetComponent<Rigidbody2D>();
        positionY = transform.position.y;
     }
 
 
     
 
     void Update(){
         
         //rotate to look at the player
         transform.LookAt(player.position);
         transform.Rotate(new Vector3(0,-90,0),Space.Self);//correcting the original rotation
         transform.position = new Vector3(transform.position.x , positionY , transform.position.z);
         
         
         
         //move towards the player
        if (Vector3.Distance(transform.position,player.position) < 5f)
        {
            if(SwordMasterAnimation.isDead == true)
            {
                transform.Translate(new Vector3(0* Time.deltaTime,0,0) );

            }
            if(Vector3.Distance(transform.position,player.position) < 3f){
                isWalk = false;
                attackAnim = true;
                isAttack = true;
            }
            else
            {
                isWalk = true;
                attackAnim = false;
                isAttack = false;

            }
             isWalk = true;
             transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
             transform.position = new Vector3(transform.position.x , transform.position.y , transform.position.z);
             transform.rotation = Quaternion.Euler(0,0,0);
             if(player.transform.position.x - transform.position.x > 0)
             {
                transform.rotation = Quaternion.Euler(0,180,0);
             }
             
        }
        else
        {
            transform.Translate(new Vector3(0* Time.deltaTime,0,0) );
            isWalk = false;

            
             
 
        }

    
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "AttackObjectFront")
        {
            rb.AddForce(Vector2.right * 250);
        }
        if(other.gameObject.tag == "AttackObjectBack")
        {
            rb.AddForce(Vector2.left * 250);
        }
    }
}
