using System;
using UnityEngine;

public class ConcreteEnemyAnimalModel : ConcreteEnemyModel
{
    protected Transform playerTransform;

    public override void Move()
    {
        EnemiesMovingMethod.Instance().Basic(transform, ref playerTransform);
    }

}
