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

    public AsyncOperation asyncLoadPlayScene;

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
        Time.timeScale = 0f;
    }
    private void CallGameStart()
    {
        OnGameStart?.Invoke();
    }
    public void LoadGamePlayScene()
    {
        DataManager.instance.LoadData();
        asyncLoadPlayScene = SceneManager.LoadSceneAsync("GamePlayScene");
        CallGamePlay();
        Time.timeScale = 1.0f;
    }
    public void LoadGameStartScene()
    {
        DataManager.instance.SaveData();
        SceneManager.LoadScene("GameStartScene");
        CallGameStart();
        Time.timeScale = 1.0f;
    }
}
