using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float dirX;
    private float moveSpeed;
    private Rigidbody2D rb;
    private Vector3 localScale;






    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        moveSpeed = 3f;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Wall>())
        {
            dirX *= -1f;
        }
    }
 
    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    //void LateUpdate()
    //{
    //    CheckWhereToFace();
    //}

    //void CheckWhereToFace()
    //{
    //    if (dirX > 0)
    //        facingRight = true;
    //}





}

