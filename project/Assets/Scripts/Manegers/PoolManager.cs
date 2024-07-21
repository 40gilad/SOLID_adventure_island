using System.Collections.Generic;
using UnityEngine;

public class PoolManager : MonoBehaviour
{
    private static PoolManager _instance;
    private Dictionary<string, Pool> pools;

    public static PoolManager Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject singletonObject = new GameObject("PoolManager");
                _instance = singletonObject.AddComponent<PoolManager>();
            }
            return _instance;
        }
    }

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
            Init();
        }
        else if (_instance != this)
            Destroy(gameObject);
    }

    private void Init()
    {
        pools = new Dictionary<string, Pool>();
    }

    public void CreatePool(GameObject prefab, int poolSize)
    {
        if (pools.ContainsKey(prefab.name))
            return;

        Pool newPool = new Pool(prefab, poolSize);
        pools.Add(prefab.name, newPool);
    }

    public GameObject GetObjectFromPool(string poolName)
    {
        if (pools.ContainsKey(poolName))
            return pools[poolName].GetObject();
        return null;
    }

    public void ReturnObjectToPool(GameObject obj)
    {
        if (pools.ContainsKey(obj.name))
            pools[obj.name].ReturnObject(obj);
        else
            Destroy(obj);
    }
}
