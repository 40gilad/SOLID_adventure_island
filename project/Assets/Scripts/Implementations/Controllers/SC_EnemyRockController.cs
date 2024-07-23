using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnemyRockController : ConcreteEnemyController
{
    protected override void Init()
    {
        model = gameObject.AddComponent<SC_EnemySpiderModel>();
        model.Initialize(this,damage);
    }
}
