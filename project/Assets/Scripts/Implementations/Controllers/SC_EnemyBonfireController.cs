using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnemyBonefireController : ConcreteEnemyController
{
    protected override void Init()
    {
        model = gameObject.AddComponent<SC_EnemyBonefireModel>();
        model.Initialize(this, damage);
    }
}
