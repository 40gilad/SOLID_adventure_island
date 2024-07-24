using System;
using UnityEngine;

public class ConcreteEnemyAnimalModel : ConcreteEnemyModel
{
    protected Transform playerTransform;

    public override void PlayerCollider(Collider2D other)
    {
        Debug.Log("Player touch animal. player lives dec");
    }

    protected override void BoomerangCollider()
    {
        Debug.Log(this.GetType().Name+" "+ System.Reflection.MethodBase.GetCurrentMethod().Name);
        controller.Died();
    }

    protected override void HammerCollider()
    {
        Debug.Log(this.GetType().Name + " " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        controller.Died();
    }

    protected override void FireBallCollider()
    {
        Debug.Log(this.GetType().Name + " " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        //controller.Died();
    }
    public override void Move()
    {
        EnemiesMovingMethod.Instance().Basic(transform, ref playerTransform);
    }

    protected override void PlayerFriendEnemyCollider()
    {
    }
}
