using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnemyRockController : ConcreteEnemyController
{
    protected override void BoomerangCollide()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    protected override void HammerCollide()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    protected override void PlayerCollide()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
}
