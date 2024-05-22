using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [SerializeField] private GameObject GameStartButtons;
    [SerializeField] private GameObject GamePlayButtons;
    [SerializeField] private GameObject GameEndPannel;

    void Start()
    {
        SystemManager.instance.OnGamePlay += GamePlayButtonsActive;
        SystemManager.instance.OnGamePlay += GameStartButtonsDisActive;


        SystemManager.instance.OnGameStart += GameStartButtonsActive;
        SystemManager.instance.OnGameStart += GamePlayButtonsDisActive;

        SystemManager.instance.OnGameOver += GameEndPannelAvtive;
    }

    private void GamePlayButtonsActive()
    {
        GamePlayButtons.SetActive(true);
    }
    private void GamePlayButtonsDisActive()
    {
        GamePlayButtons.SetActive(false);
    }

    private void GameStartButtonsActive()
    {
        GameStartButtons.SetActive(true);
    }

    private void GameStartButtonsDisActive()
    {
        GameStartButtons.SetActive(false);
    }

    private void GameEndPannelAvtive()
    {
        GameEndPannel.SetActive(true);
    }
}
