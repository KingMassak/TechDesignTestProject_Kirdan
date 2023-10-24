using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField] private float moveSpeed = 5f;
    private Vector2 angleMove;
    private bool isMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.drag = 20;
    }

    private void FixedUpdate()
    {
        if (isMove)
        {
            Move();
        }
    }

    void Move()
    {
        angleMove.x = Input.GetAxisRaw("Horizontal");
        angleMove.y = Input.GetAxisRaw("Vertical");
        rb.MovePosition(rb.position + angleMove * moveSpeed * Time.fixedDeltaTime);
    }
}
