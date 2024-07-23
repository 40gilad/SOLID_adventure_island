using System;
using UnityEngine;

public class ConcreteEnemyAnimalModel : ConcreteEnemyModel
{
    protected Transform playerTransform;

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

    protected override void FireBallCollider()
    {
        Debug.Log(this.GetType().Name + " " + System.Reflection.MethodBase.GetCurrentMethod().Name);
        //controller.Died();
    }
    public override void Move()
    {
        //face to player
        try
        {
            if (playerTransform.position.x > transform.position.x && transform.localScale.x > 0)
                Flip();
            else if (playerTransform.position.x < transform.position.x && transform.localScale.x < 0)
                Flip();
        }
        catch (NullReferenceException)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        }
    }

    protected void Flip()
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the x scale to change direction
        transform.localScale = scale;
    }

}
