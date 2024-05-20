using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class PlayerSetting : MonoBehaviour
{

    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private PlayerController controller;
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        controller = GetComponent<PlayerController>();
        LoadPlayerData(GameManager.instance.CharacterInfor());        
    }
    private void LoadPlayerData(PlayerSO pl)
    {
        GameObject obj = pl.playerObj;
        animator.runtimeAnimatorController = obj.GetComponent<Animator>().runtimeAnimatorController;
        spriteRenderer.sprite = obj.GetComponent<SpriteRenderer>().sprite;

        controller.CallSettingEvet(pl);
    }
}
