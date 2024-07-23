using UnityEngine;

public class ConcreteEnemyAnimalModel : ConcreteEnemyModel
{

    public override void PlayerCollider()
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

    public override void Move()
    {
        Debug.Log(this.GetType().Name + " " + System.Reflection.MethodBase.GetCurrentMethod().Name);
    }
}
