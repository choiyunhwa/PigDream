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
        SystemManager.instance.OnGamePlay += ScoreClear;
        SystemManager.instance.OnGameOver += GameEnd;
    }

    public void ScoreEarn(int scorePoint)
    {
        currentScore += scorePoint;
        scoreTxt.text = currentScore.ToString();
    }

    private void ScoreClear()
    {
        currentScore = 0;
        ScoreEarn(0);
    }

    private void GameEnd()
    {
        currentScoreTxt.text = currentScore.ToString();
    }
}
