using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnemyGhostController : ConcreteEnemyAnimalController
{
    protected override void Init()
    {
        model = gameObject.AddComponent<SC_EnemyGhostModel>();
        model.Initialize(this, damage);

    }
}
