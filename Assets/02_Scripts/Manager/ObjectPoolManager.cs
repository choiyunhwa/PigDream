using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    private bool collectionChecks = true;

    public int maxPoolSize = 10;
    public List<GameObject> prefabs;

    //public IObjectPool<GameObject> pool { get; private set; }
    public Dictionary<string, IObjectPool<GameObject>> poolDic { get; set; }

    private void Awake()
    {      
        if (instance != null)
            Destroy(gameObject);        
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        InitPoolSetting();


    }

    private void Start()
    {
        //SystemManager.instance.OnGamePlay += InitPoolSetting;
    }

    private void InitPoolSetting()
    {
        poolDic = new Dictionary<string, IObjectPool<GameObject>>();

        foreach (var prefab in prefabs)
        {
            IObjectPool<GameObject> pool = new ObjectPool<GameObject>(() => CreatePooledItem(prefab), OnTakeFromPool, OnReturnedToPool, OnDestroyPoolObject, collectionChecks, 10, maxPoolSize);

            poolDic[prefab.name] = pool;


            for (int i = 0; i < maxPoolSize; i++)
            {
                var ps = pool.Get(); //풀에서 인스턴스를 가져옴. 비어있으면 새 인스턴스 생성
                pool.Release(ps);   
            }
        }

    }

    private GameObject CreatePooledItem(GameObject prefab)
    {
        GameObject poolGo = Instantiate(prefab, this.transform);
        return poolGo;
    }

    /// <summary>
    /// 
    /// </summary>
    /// <param name="pool"></param>
    private void OnReturnedToPool(GameObject pool)
    {
        pool.SetActive(false);
    }

    private void OnTakeFromPool(GameObject pool)
    {
        pool.SetActive(true);
    }

    private void OnDestroyPoolObject(GameObject pool)
    {
        Destroy(pool);
    }

}