using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Factory
{
    protected PrefabManager _prefabManager;

    public void Initialize(PrefabManager prefabManager)
    {
        _prefabManager = prefabManager;
    }
    public virtual ConcreteCollectible CreateCollectible(string type)
    {
        if (_prefabManager == null)
            throw new InvalidOperationException("GameManager must initilize FruitsFactory first");
        return null;
    }

    public virtual ConcreteEnemyController CreateEnemy(string type)
    {
        if (_prefabManager == null)
            throw new InvalidOperationException("GameManager must initilize EnemiesFactory first");
        return null;
    }
}
