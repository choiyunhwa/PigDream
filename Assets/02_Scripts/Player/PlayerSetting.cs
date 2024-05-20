using System.Collections;
using System.Collections.Generic;
using UnityEditor.Animations;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    public PlayerSO player;

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        LoadPlayerData();
    }

    private void LoadPlayerData()
    {
        player = Resources.Load<PlayerSO>(GameManager.instance.CharacterInfor());

        GameObject obj = player.playerObj;
        animator.runtimeAnimatorController = obj.GetComponent<Animator>().runtimeAnimatorController;
        spriteRenderer.sprite = obj.GetComponent<SpriteRenderer>().sprite; 
    }
}
