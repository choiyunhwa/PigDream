using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoodAnimator : MonoBehaviour
{
    private readonly int isHit = Animator.StringToHash("isHit");

    private Animator animator;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }

    public void IsHit(bool value)
    {
        animator.SetBool(isHit, value);
    }
}
