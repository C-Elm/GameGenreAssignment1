using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallJump : MonoBehaviour
{

    public float wallJumpSpeed = 8f;
    public Transform wallCheck;
    public float wallCheckRadius;
    public LayerMask wallLayer;
    private bool isTouchingWall;

    public bool jumpReady;
    public float jumpCD = 1.2f;
    public float jumpCDCurrent = 0.0f;

    private Rigidbody2D rb;
    //private float moveDirection;


    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        isTouchingWall = Physics2D.OverlapCircle(wallCheck.position, wallCheckRadius, wallLayer);

        if (jumpCDCurrent >= jumpCD)
        {
            jumpReady = true;
        }
        else
        {
            jumpCDCurrent = jumpCDCurrent + Time.deltaTime;
            jumpReady = false;
        }

         if (Input.GetButtonDown("Jump") && isTouchingWall && jumpReady)
        {
            rb.velocity = new Vector2(rb.velocity.x, wallJumpSpeed);
            jumpCDCurrent = 0.0f;
        }


        //rb.velocity = new Vector2(moveDirection * moveSpeed, rb.velocity.y);

    }





}
