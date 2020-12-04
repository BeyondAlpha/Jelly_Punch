using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float maxSpeed;
    public float jumpPower;
    Rigidbody2D rigid;
    Transform transform;
    SpriteRenderer spriteRenderer;
    Animator animator;
    public List<Note> notes = new List<Note>();

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {   // KeyBoardGame
        
        
        //Jump
        if (Input.GetButtonDown("Jump") && !animator.GetBool("isJumping"))
        {
            rigid.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            animator.SetBool("isJumping", true);
        }
        // Stop move
        if(Input.GetButtonUp("Horizontal")) 
        {
            rigid.velocity = new Vector2(rigid.velocity.normalized.x *0.5f, rigid.velocity.y);
        }
        // Direction Sprite
        if(Input.GetButton("Horizontal"))
        {
            spriteRenderer.flipX = Input.GetAxisRaw("Horizontal") == -1;
        }
        // Animation
        if(Input.GetAxisRaw("Horizontal") == 0)
        {
            animator.SetBool("iswalking", false);
        }
        else
        {
            animator.SetBool("iswalking", true);
        }
    }
    void FixedUpdate()
    {
        //Move Speed
        float h = Input.GetAxisRaw("Horizontal");
        rigid.AddForce(Vector2.right * h, ForceMode2D.Impulse);

        int _Ground = 1<<LayerMask.NameToLayer("Platform");
        
        //Max Speed
        if (rigid.velocity.x > maxSpeed) //Right Max Speed
            rigid.velocity = new Vector2(maxSpeed, rigid.velocity.y); 
        else if (rigid.velocity.x < maxSpeed * (-1)) //Left Max Speed
            rigid.velocity = new Vector2(maxSpeed * (-1), rigid.velocity.y); 

        //Landing Platform
        if(rigid.velocity.y < 0) {
            Debug.DrawRay(transform.position, Vector3.down, new Color(1,0,0));
            
            RaycastHit2D rayHit = Physics2D.Raycast(rigid.position, Vector3.down, 1, _Ground);
            
            if(rayHit.collider != null) {
                Debug.Log(rayHit.collider.name);
                animator.SetBool("isJumping", false);
            }
        }
    }
}
