using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] GameObject player;
    
    public float jumpPower;
    public static float horizontalSpeed;
    public static bool isGrounded = false;
    public float speed = 10;
    private bool isDead = false;
    
    private int can = 100;
    Rigidbody2D rb;
    SpriteRenderer sr;
    

    // Start is called before the first frame update
    void Start()
    {
        jumpPower = 7f;
        speed = 0.05f;
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerRotation();
        PlayerJump();
        horizontalSpeed = Input.GetAxisRaw("Horizontal") * speed * Time.deltaTime * 100;
        transform.Translate(new Vector3(horizontalSpeed , 0 , 0));
        if(isDead == true){
            StartCoroutine(Dead());
        }
        

        

        
    }
    void PlayerRotation()
    {
        if(Input.GetAxisRaw("Horizontal") == -1)
        {
            sr.flipX = true;
        }
        if(Input.GetAxisRaw("Horizontal") == 1){
            sr.flipX = false;
        }
        
    }
    void PlayerJump()
    {
        if(Input.GetKeyDown(KeyCode.Space) & isGrounded == true)
        {
            rb.AddForce(Vector2.up * jumpPower , ForceMode2D.Impulse);
            isGrounded = false;
        }

    }
    IEnumerator Dead(){
        yield return new WaitForSeconds(3);
        gameObject.SetActive(false);
    }

    
    private void OnCollisionEnter2D(Collision2D other)
    {
        if((other.gameObject.tag == "Ground") || (other.gameObject.tag == "Platform"))
        {
            isGrounded = true;
        }
        if(other.gameObject.tag == "Spikes")
        {
            isDead = true;

        }
        if(other.gameObject.tag == "Level2")
        {
            SceneManager.LoadScene("Level2");
        }
        if(other.gameObject.tag == "Level3"){
            SceneManager.LoadScene("Level3");
        }
        if(other.gameObject.tag == "SoldierAttack"){
            can = can-10;
            Debug.Log(can);
            rb.AddForce(Vector2.left * 500);
        }
        
    }
}
