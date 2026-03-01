using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;

public class PLayer : MonoBehaviour
{

    public float Speed = 10;
    public Rigidbody2D rb;

    public Animator anim;
    public SpriteRenderer spr;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        walk();
        Flip();

    }

    public Vector2 moveVector;
    public float speed = 4f;

    void walk()
    {

        moveVector.x = Input.GetAxisRaw("Horizontal");
        anim.SetFloat("moveY", Mathf.Abs(moveVector.x));
        rb.velocity = new Vector2(moveVector.x * speed, rb.velocity.y);

        moveVector.y = Input.GetAxisRaw("Vertical");
        if (moveVector.y < 0)
        {
            anim.SetFloat("moveX", Mathf.Abs(moveVector.y));
            anim.SetFloat("moveX", 1);
        }
        else if (moveVector.y > 0)
        {
            anim.SetFloat("moveeX", Mathf.Abs(moveVector.y));
            anim.SetFloat("moveeX", 1);
        }
        else
        {
            anim.SetFloat("moveeX", 0);
            anim.SetFloat("moveX", 0);
        }
        rb.velocity = new Vector2(rb.velocity.x, moveVector.y * speed);
    }

    void Flip()
    {
        spr.flipX = moveVector.x < 0;
    }


}


