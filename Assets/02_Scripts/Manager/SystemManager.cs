using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemManager : MonoBehaviour
{
    public static SystemManager instance;

    public event Action OnGamePlay;
    public event Action OnGameOver;
    public event Action OnGameStart;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
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
