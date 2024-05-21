using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [Range(0, 10)] public float foodSpawnSpeed = 3f;
    [Range(0, 10)] public float AvoidfoodSpawnSpeed = 6f;
    [Range(0, 10)] public float PowerUPSpawnSpeed = 10f;

    [SerializeField] private GameObject food;
    [SerializeField] private GameObject avoidFood;
    [SerializeField] private GameObject powerUP;

    [SerializeField] private float MaxDifficult = 29f;
    [SerializeField] private float currentDifficult;
    [SerializeField] private float DifficultCap = 0.1f;

    public float speedScaling;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        { Destroy(gameObject); }
    }

    void Start()
    {
        SystemManager.instance.OnGamePlay += StartAllCoroutine;
        SystemManager.instance.OnGameStart += StopAllCoroutine;
        SystemManager.instance.OnGameOver += StopAllCoroutine;
    }

    private void StartAllCoroutine()
    {
        StartCoroutine(SpawnFood());
        StartCoroutine(SpawnAvoidFood());
        StartCoroutine(SpawnPowerUPs());
        StartCoroutine(DifficultScaling());
        
        // 초기 세팅
        speedScaling = 0;
        currentDifficult = 0;
    }

    private void StopAllCoroutine()
    {
        StopAllCoroutines();
    }

    IEnumerator DifficultScaling()
    {
        while (currentDifficult < MaxDifficult)
        {
            yield return new WaitForSeconds(3f);
            currentDifficult += 0.5f;
            speedScaling += 0.1f;
        }
    }

    IEnumerator SpawnFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(foodSpawnSpeed - (currentDifficult * DifficultCap));
            //ObjectPoolManager.instance.poolDic["Food"].Get();
            Instantiate(food);
        }
    }
    IEnumerator SpawnAvoidFood()
    {
        while (true)
        {
            yield return new WaitForSeconds(AvoidfoodSpawnSpeed - (currentDifficult * DifficultCap) * 2); // 맨 뒤는 추가 캡을 넣어주도록
            //ObjectPoolManager.instance.poolDic["AvoidFood"].Get();
            Instantiate(avoidFood);
        }
    }
    IEnumerator SpawnPowerUPs()
    {
        while (true)
        {
            yield return new WaitForSeconds(PowerUPSpawnSpeed - (currentDifficult * DifficultCap));
            //ObjectPoolManager.instance.poolDic["PowerUP"].Get();
            Instantiate(powerUP);
        }
    }
}