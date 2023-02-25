using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    private Animator animator;
    Rigidbody2D rb;
    private bool isGrounded = false;
    private bool isDead = false;
    private bool isAttack = false;
    
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)){
            isGrounded = false;
        }
        if(Input.GetKeyDown(KeyCode.X)){
            isAttack = true;
        }
        
        Run();
        Jump();
        Crouch();
        Dead();
        Attack();
    }
    void Run()
    {
        if(Input.GetAxisRaw("Horizontal") != 0)
        {
            animator.SetBool("IsRun" , true);

        }
        if(Input.GetAxisRaw("Horizontal") == 0){
            animator.SetBool("IsRun" , false);
        }
        
    }
    void Jump()
    {
        if(rb.velocity.y > 0 & isGrounded == false)
        {
            animator.SetInteger("IsJump" , 1);
        }
        if(rb.velocity.y < 0 & isGrounded == false)
        {
            animator.SetInteger("IsJump" , -1);
        }
        if(isGrounded == true)
        {
            animator.SetInteger("IsJump" , 0);
        }
      
    }
    void Crouch()
    {
        if(Input.GetKey(KeyCode.DownArrow))
        {
            animator.SetBool("IsCrouch" , true);
        }
        else{
            animator.SetBool("IsCrouch" , false);
        }

    }
    void Dead(){
        if(isDead == true)
        {
            animator.SetBool("IsDead" , true);
        }
    }

    void Attack()
    {
        if(isAttack == true)
        {
            animator.SetBool("IsAttack" , true);
            isAttack = false;

        }
        else
        {
            animator.SetBool("IsAttack" , false);

        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.tag == "Ground") || (other.gameObject.tag == "Platform" ))
        {
            isGrounded = true;

        }
        if(other.gameObject.tag == "Spikes")
        {
            isDead = true;
        }
        
    }
}
