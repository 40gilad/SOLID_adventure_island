using System;
using UnityEngine;

public class EnemiesFactory : Factory
{
    /*
    public override ConcreteEnemyController CreateCollectible(string type)
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

        return GameObject.Instantiate(prefab).GetComponent<ConcreteEnemyController>();
    }
    */
}
