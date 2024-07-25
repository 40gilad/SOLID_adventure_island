using System;
using UnityEngine;

public class EnemiesFactory : Factory
{
    public override ConcreteEnemyController CreateEnemy(string type)
    {
        base.CreateCollectible(null); //make sure that factory was initialize
        GameObject prefab = null;

        switch (type)
        {
            case "Rock":
                prefab = _prefabManager.RockEnemyPrefab;
                break;
            case "Bonfire":
                prefab = _prefabManager.BonfireEnemyPrefab;
                break;
            case "Bird":
                prefab = _prefabManager.BirdEnemyPrefab;
                break;
            case "Snake":
                prefab = _prefabManager.SnakeEnemyPrefab;
                break;
            case "Ghost":
                prefab = _prefabManager.GhostEnemyPrefab;
                break;
            case "Spider":
                prefab = _prefabManager.SpiderEnemyPrefab;
                break;
            case "Frog":
                prefab = _prefabManager.FrogEnemyPrefab;
                break;
            default:
                throw new ArgumentException(type);
        }

        if (prefab == null)
            throw new ArgumentException("Prefab not found");
        return GameObject.Instantiate(prefab).GetComponent<ConcreteEnemyController>();
    }
}
