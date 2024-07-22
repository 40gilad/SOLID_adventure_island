using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnemyRockController : ConcreteEnemyController
{
    protected override void Init()
    {
        model = new SC_EnemyRockModel(this,damage);
    }
}
