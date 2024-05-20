using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject gameOverPannel;
    [SerializeField] private Text scoreTxt;
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI bestScoreTxt;

    // 인게임 매니저들
    [SerializeField] private GameObject spawnManager;

    private PlayerSO[] playerInfors;

    private PlayerSO SelectchracterName;
    private int currentScore;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        SystemManager.instance.OnGamePlay += GamePlaySetting;
        SystemManager.instance.OnGameOver += GameEnd;
        SystemManager.instance.OnGameStart += GameMenu;

        playerInfors = Resources.LoadAll<PlayerSO>("Player");
    }

    public void ScoreEarn(int scorePoint)
    {
        currentScore += scorePoint;
        scoreTxt.text = currentScore.ToString();
    }

    private void GamePlaySetting()
    {
        spawnManager.SetActive(true);
        currentScore = 0;
        ScoreEarn(0);
    }

    private void GameEnd()
    {
        currentScoreTxt.text = currentScore.ToString();
    }

    private void GameMenu()
    {
        spawnManager.SetActive(false);
    }

    public void CharacterSetting(PlayerSO character)
    {
        SelectchracterName = character;
    }

    public PlayerSO CharacterInfor()
    {
        return SelectchracterName;    
    }

    public PlayerSO[] AllCharacterInfor()
    {
        return playerInfors;
    }

}
