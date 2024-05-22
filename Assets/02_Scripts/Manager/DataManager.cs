using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System;

public class GameData
{
    public int bestscore = 0;
}

public class DataManager : MonoBehaviour
{
    public readonly string gameDataFileName = "PigDream.json";
    public static DataManager instance;

    private GameData gameData;
    public GameData GameData
    {
        get 
        { 
            if(gameData == null)
            {
                LoadData();
                SaveData();
            }
            
            return gameData;
        }
        set
        {
            gameData = value;
        }
    }


    private void Awake()
    {
        if (instance != null)
            Destroy(gameObject);
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadData()
    {
        string filePath = Application.streamingAssetsPath + gameDataFileName;

        if(File.Exists(filePath)) 
        {            
            string FromJsonData = File.ReadAllText(filePath);
            gameData = JsonUtility.FromJson<GameData>(FromJsonData);
            Debug.Log("불러오기 성공");
        }
        else
        {
            gameData = new GameData();
        }
    }

    public void SaveData()
    {
        string ToJsonData = JsonUtility.ToJson(gameData);
        string filePath = Application.streamingAssetsPath + gameDataFileName;
        File.WriteAllText(filePath, ToJsonData);
        Debug.Log("저장하기 성공");
    }
}
