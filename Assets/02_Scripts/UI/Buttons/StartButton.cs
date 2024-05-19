using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartButton : MonoBehaviour
{
    [SerializeField] private GameObject SellectPannel;

    public void GameStart()
    {
        SoundManager.instance.PlayClickSound();
        SellectPannel.SetActive(false);
        SystemManager.instance.LoadGamePlayScene();
    }
}
