using System;
using UnityEngine;

public class FruitsFactory
{
    protected static PrefabManager _prefabManager;

    public static void Initialize(PrefabManager prefabManager)
    {
        _prefabManager = prefabManager;
    }
    public static Concrete_ColFruit CreateCollectible(string type)
    {
        if (_prefabManager == null)
            throw new InvalidOperationException("GameManager must initilize FruitsFactory first");

        GameObject prefab = null;

        switch (type)
        {
            case "Pineapple":
                prefab = _prefabManager.ColPineapplePrefab;
                break;
            default:
                throw new ArgumentException(type);
        }

        if (prefab == null)
            throw new ArgumentException("Prefab not found");

        GameObject instance = GameObject.Instantiate(prefab);
        return instance.GetComponent<Concrete_ColFruit>();
    }
}



/*
 
 ******************* FACTORY WITH POOLING SYSTEM *******************
 using System;
using UnityEngine;
using UnityEngine.Pool;

public class FruitsFactory : MonoBehaviour
{
    private ObjectPool<ColeP> _pineapplePool;
    private ObjectPool<Apple> _applePool;
    private ObjectPool<Weapon> _weaponPool;

    public void InitializePools(Pineapple pineapplePrefab, Apple applePrefab, Weapon weaponPrefab, int initialCapacity)
    {
        _pineapplePool = new ObjectPool<Pineapple>(pineapplePrefab, initialCapacity);
        _applePool = new ObjectPool<Apple>(applePrefab, initialCapacity);
        _weaponPool = new ObjectPool<Weapon>(weaponPrefab, initialCapacity);
    }

    public Collectible CreateCollectible(string type)
    {
        switch (type)
        {
            case "Pineapple":
                return _pineapplePool.GetObject();
            case "Apple":
                return _applePool.GetObject();
            case "Weapon":
                return _weaponPool.GetObject();
            default:
                throw new ArgumentException("Invalid type");
        }
    }

    public void ReturnCollectible(Collectible collectible)
    {
        switch (collectible)
        {
            case Pineapple pineapple:
                _pineapplePool.ReturnObject(pineapple);
                break;
            case Apple apple:
                _applePool.ReturnObject(apple);
                break;
            case Weapon weapon:
                _weaponPool.ReturnObject(weapon);
                break;
            default:
                throw new ArgumentException("Invalid collectible");
        }
    }
}

*/