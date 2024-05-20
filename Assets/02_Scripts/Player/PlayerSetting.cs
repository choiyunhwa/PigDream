using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSetting : MonoBehaviour
{
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        SystemManager.instance.OnGamePlay += LoadPlayerData;
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LoadPlayerData()
    {
        PlayerSO player = Resources.Load<PlayerSO>(GameManager.instance.CharacterInfor());

        GameObject obj = player.playerObj;
        animator = obj.GetComponent<Animator>();
        spriteRenderer = obj.GetComponent<SpriteRenderer>(); 
    }
}
