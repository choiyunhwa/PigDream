using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rigid;

    private Vector3 movementDirection = Vector3.zero;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }
    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * 5;
        rigid.velocity = direction;
    }
}
