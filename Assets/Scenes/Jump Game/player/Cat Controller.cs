using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
    float horizontalInput;
    float moveSpeed = 5f;
    bool isFacingRight = false;
    float jumpPower = 5f;
    bool isGrounded = false;

    Rigidbody2D rb;
    Animator animator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");

        FlipSprite();
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpPower);
            isGrounded = false;
            animator.SetBool("IsJumping", isGrounded);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        animator.SetFloat("xVelocity", Mathf.Abs(rb.velocity.x));
        animator.SetFloat("yVelocity", rb.velocity.y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isGrounded = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGrounded = true;
        animator.SetBool("IsJumping", !isGrounded);
    }

    private void FlipSprite()
    {
        if (horizontalInput > 0f && !isFacingRight)
        {
            isFacingRight = true;
            Vector3 ls = transform.localScale;
            ls.x = Mathf.Abs(ls.x);
            transform.localScale = ls;
        }
        else if (horizontalInput < 0f && isFacingRight)
        {
            isFacingRight = false;
            Vector3 ls = transform.localScale;
            ls.x = -Mathf.Abs(ls.x);
            transform.localScale = ls;
        }
    }
}