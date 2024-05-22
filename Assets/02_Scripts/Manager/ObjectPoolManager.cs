using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    public static ObjectPoolManager instance;

    [System.Serializable]
    public class Pool
    {
        public string tag;
        public List<GameObject> prefabs;
        public int size;
    }

    public List<Pool> Pools;
    private Dictionary<string, List<GameObject>> PoolDictionary;

    public Vector2 powerUpSize = Vector2.one;
    private int bigSizeDuration;
    private int smallSizeDuration;

    private int powerUpMaxCount;
    private int powerUpCurrentCount;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else { Destroy(this.gameObject); }
    }

    void Start()
    {
        SystemManager.instance.OnGamePlay += DelaySpawn;
        SystemManager.instance.OnGameOver += CleanObjectPool;
    }

    private void CleanObjectPool()
    {
        PoolDictionary.Clear();
    }

    private void DelaySpawn()
    {
        StartCoroutine(DelaySpawnCoroutine());
        bigSizeDuration = 0;
        smallSizeDuration = 0;
    }

    IEnumerator DelaySpawnCoroutine()
    {
        yield return new WaitUntil(() => SystemManager.instance.asyncLoadPlayScene.isDone == true);
        InitGameObjectPool();
    }

    public void InitGameObjectPool()
    {
        PoolDictionary = new Dictionary<string, List<GameObject>>();
        foreach (var pool in Pools)
        {
            // GameObject ParentObject = new GameObject(pool.tag);
            // Instantiate(ParentObject);
            List<GameObject> objectPool = new List<GameObject>();
            for (int i = 0; i < pool.size; i++)
            {
                GameObject obj = Instantiate(pool.prefabs[i % pool.prefabs.Count]);

                obj.SetActive(false);

                objectPool.Add(obj);
            }
            if (pool.tag == "PowerUp") { powerUpMaxCount = objectPool.Count; }
            PoolDictionary.Add(pool.tag, objectPool);
        }
    }

    public GameObject SpawnFromPool(string tag)
    {
        // 애초에 Pool이 존재하지 않는 경우
        if (!PoolDictionary.ContainsKey(tag))
            return null;

        //
        List<GameObject> objectPool = PoolDictionary[tag];
        if (objectPool.Count == 0)
        {
            PoolSizeExpand(tag, objectPool);
        }

        int i = objectPool.Count - 1;
        GameObject obj = objectPool[i];
        objectPool.RemoveAt(i);
        objectPool.Insert(0, obj);

        if (obj.activeSelf)
        {
            PoolSizeExpand(tag, objectPool);
            i = objectPool.Count - 1;
            obj = objectPool[i];
            objectPool.RemoveAt(i);
            objectPool.Insert(0, obj);
        }

        // 위치 이동
        float x = Random.Range(-2.45f, 2.45f);
        obj.transform.position = new Vector2(x, 5.2f);


        // 파워업 적용 (파워업들은 제외)
        if (tag != "PowerUp") { obj.transform.localScale = powerUpSize; }
        else
        {
            if (powerUpCurrentCount == powerUpMaxCount)
            {
                PoolDictionary[tag] = objectPool.OrderBy(a => Random.Range(0, objectPool.Count)).ToList();
                powerUpCurrentCount = 0;
            }
            else
            { powerUpCurrentCount++; }
        }

        obj.SetActive(true);

        return obj;
    }

    void PoolSizeExpand(string tag, List<GameObject> objectPool)
    {
        foreach (var pool in Pools)
        {
            if (pool.tag == tag)
            {
                //GameObject ParentObject 
                for (int i = 0; i < pool.prefabs.Count; i++)
                {
                    GameObject obj = Instantiate(pool.prefabs[i]);
                    obj.SetActive(false);
                    objectPool.Add(obj);
                }
                if (tag == "PowerUp") { powerUpMaxCount = objectPool.Count; }
                return;
            }
        }
    }

    // 파워업 관련

    public void PowerUPSizeChange(int SmallorBig)
    {
        if (SmallorBig == 0)
        {
            if (smallSizeDuration <= 0 && bigSizeDuration > 0) { bigSizeDuration = 0; StopCoroutine("PowerUPSizeBig"); StartCoroutine("PowerUPSizeSmall"); }
            else if (smallSizeDuration <= 0) { StartCoroutine("PowerUPSizeSmall"); }
            else { smallSizeDuration += 10; }
        }
        else if (SmallorBig == 1)
        {
            if (bigSizeDuration <= 0 && smallSizeDuration > 0) { smallSizeDuration = 0; StopCoroutine("PowerUPSizeSmall"); StartCoroutine("PowerUPSizeBig"); }
            else if (bigSizeDuration <= 0) { StartCoroutine("PowerUPSizeBig"); }
            else { bigSizeDuration += 10; }
        }
    }

    IEnumerator PowerUPSizeSmall()
    {
        smallSizeDuration = 10;
        powerUpSize = Vector2.one * 0.5f;
        while (smallSizeDuration > 0)
        {
            yield return new WaitForSeconds(1f);
            smallSizeDuration -= 1;
        }
        powerUpSize = Vector2.one;
    }

    IEnumerator PowerUPSizeBig()
    {
        bigSizeDuration = 10;
        powerUpSize = Vector2.one * 2;
        while (bigSizeDuration > 0)
        {
            yield return new WaitForSeconds(1f);
            bigSizeDuration -= 1;
        }
        powerUpSize = Vector2.one;
    }
}