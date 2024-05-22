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
    [SerializeField] private GameObject NewScore;
    [SerializeField] private TextMeshProUGUI currentScoreTxt;
    [SerializeField] private TextMeshProUGUI bestScoreTxt;

    // 인게임 매니저들
    [SerializeField] private GameObject spawnManager;

    private PlayerSO[] playerInfors;

    private PlayerSO SelectchracterName;
    private int currentScore;
    private int bestScore;

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

        DataManager.instance.LoadData();
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
        LoadBestScoreData();
        ScoreEarn(0);
    }

    private void LoadBestScoreData()
    {
        bestScore = DataManager.instance.GameData.bestscore;
        bestScoreTxt.text = bestScore.ToString();
    }

    private int CheckBestScore()
    {
        if(currentScore > bestScore)
        {
            SoundManager.instance.NewScore();
            NewScore.SetActive(true);
            return bestScore = currentScore;
        }

        return bestScore;
    }

    private void GameEnd()
    {
        SoundManager.instance.PlayHitSound();
        SoundManager.instance.GameOver();
        currentScoreTxt.text = currentScore.ToString();
        DataManager.instance.GameData.bestscore = CheckBestScore();
        bestScoreTxt.text = CheckBestScore().ToString();
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
