using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_EnemyRockModel : ConcreteEnemyModel
{
    private void Start()
    {
        is_moving = false;
    }
    protected override void BoomerangCollider()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
        controller.Died();
    }

    protected override void HammerCollider()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }

    public override void PlayerCollider()
    {
        Debug.Log(System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
}
