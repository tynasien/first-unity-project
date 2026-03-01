using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catFollow : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float distanceToPlayer = 4f; // Расстояние до игрока

    private Animator animator;
    private Transform target;

    public Rigidbody2D rb;

    Vector2 Followment;

    void Start()
    {
        animator = GetComponent<Animator>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }



    void FixedUpdate()
    {
        Vector2 direction = (target.position - transform.position).normalized; // Направление к игроку
        Vector2 targetPosition = (Vector2)target.position - direction * distanceToPlayer; // Целевая позиция с учетом расстояния

        transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

        rb.MovePosition(rb.position + Followment * moveSpeed * Time.fixedDeltaTime);


    }

    void Update()
    {

        Followment.x = Input.GetAxisRaw("Horizontal"); // nalevo -1, napravo 1
        Followment.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", Followment.x);
        animator.SetFloat("Vertical", Followment.y);
        animator.SetFloat("Speed", Followment.sqrMagnitude);
    }

}