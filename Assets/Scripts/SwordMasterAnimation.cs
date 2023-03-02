using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMasterAnimation : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public static bool isDead = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(SoldierMovement.isWalk == true)
        {
            animator.SetBool("IsWalk" , true);
        }
        if(SoldierMovement.isWalk == false)
        {
            animator.SetBool("IsWalk" , false);
        }
        
        if(SoldierMovement.attackAnim == true)
        {
            animator.SetBool("IsHit" , true);
        }
        if(SoldierMovement.attackAnim == false)
        {
            animator.SetBool("IsHit" , false);
        }
        
        
        
        
    }
    

    IEnumerator Dead(){
        if(isDead == true)
        {
            animator.SetBool("IsDead" , true);
            yield return new WaitForSeconds(0.2f);
            animator.SetBool("IsDead" ,false);
            yield return new WaitForSeconds(1);
            Destroy(gameObject);
        }
    }
    
    
    
    


    

    
    
    private void OnCollisionEnter2D(Collision2D other) {
        if((other.gameObject.tag == "AttackObjectFront") || (other.gameObject.tag == "AttackObjectBack"))
        {
            isDead = true;
            
            StartCoroutine(Dead());
            
            
        }
        else
        {
            isDead = false;
        }
        
    }
}
