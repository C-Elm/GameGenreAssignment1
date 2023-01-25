using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed;
    public float jumpSpeed = 8f;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    private bool isTouchingGround;

    AudioSource jumpSound;

    private Rigidbody2D rb;
    private float moveDirection;

 


    private void Awake()
    {
      rb = GetComponent<Rigidbody2D>();

      jumpSound = GetComponent<AudioSource>();
    }

         void Update()
    {
        isTouchingGround = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, groundLayer);

        moveDirection = Input.GetAxis("Horizontal");

        if (Input.GetButtonDown("Jump") && isTouchingGround) 
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
            jumpSound.Play();
        }
      

        rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);
   
    }

 
}
