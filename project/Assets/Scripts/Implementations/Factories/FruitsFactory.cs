using System;
using UnityEngine;

public class FruitsFactory : Factory
{
    public override ConcreteCollectible CreateCollectible(string type)
    {
        base.CreateCollectible(null); //make sure that factory was initialize
        GameObject prefab = null;

        switch (type)
        {
            case "Pineapple":
                prefab = _prefabManager.ColPineapplePrefab;
                break;
            case "Grape":
                prefab = _prefabManager.ColGrapePrefab;
                break;
            default:
                throw new ArgumentException(type);
        }

        if (prefab == null)
            throw new ArgumentException("Prefab not found");

        return GameObject.Instantiate(prefab).GetComponent<Concrete_ColFruit>();
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