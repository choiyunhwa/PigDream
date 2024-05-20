using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class PlayerAnimationController : MonoBehaviour
{
    private readonly int isWalking = Animator.StringToHash("isWalk");
    private readonly int isDie = Animator.StringToHash("isDead");

    private PlayerController controller;
    private Animator animator;
    
    private SpriteRenderer spriteRenderer;

    private readonly float magnituteThreshold = 0.5f;

    private void Awake()
    {
        controller = GetComponent<PlayerController>();
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }

    private void Start()
    {

        controller.OnMoveEvent += Move;
        controller.OnDieEvent += Dead;
    }

    private void Move(Vector2 vector)
    {
        animator.SetBool(isWalking, vector.magnitude > magnituteThreshold);

        spriteRenderer.flipX = vector.x < 0;
    }

    private void Dead()
    {
        animator.SetTrigger(isDie);
    }
}
