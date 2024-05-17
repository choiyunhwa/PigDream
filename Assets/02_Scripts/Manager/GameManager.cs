using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public event Action OnGamePlay;
    public event Action OnGameOver;
    public event Action OnGameStart;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(Instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void CallGamePlay()
    {
        OnGamePlay?.Invoke();
    }
    public void CallGameOver()
    {
        OnGameOver?.Invoke();
    }
    private void CallGameStart()
    {
        OnGameStart?.Invoke();
    }
    public void LoadGamePlayScene()
    {
        SceneManager.LoadScene("GamePlayScene");
        CallGamePlay();
    }
    public void LoadGameStartScene()
    {
        SceneManager.LoadScene("GameStartScene");
        CallGameStart();
    }
}
