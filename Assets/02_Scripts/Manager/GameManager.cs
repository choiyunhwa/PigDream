using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private Text scoreTxt;

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
}
