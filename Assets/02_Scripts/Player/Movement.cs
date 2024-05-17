using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private PlayerController controller;
    private Rigidbody2D rigid;

    private Vector3 movementDirection = Vector3.zero;
    private float speed = 5f; //PlayerSO 가져오면 바꿔야함

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

    private void GetPlayerSpeed(PlayerSO player)
    {
        speed = player.speed;
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction = direction * speed;
        rigid.velocity = direction;
    }
}
