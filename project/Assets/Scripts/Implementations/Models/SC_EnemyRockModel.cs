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
        controller.Died();
    }

    protected override void HammerCollider()
    {
    }

    public override void PlayerCollider()
    {
    }

    protected override void FireBallCollider()
    {
        Debug.Log("Fireball touch Rock");
    }
}
