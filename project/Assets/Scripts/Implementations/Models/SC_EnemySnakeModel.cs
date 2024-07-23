// SC_EnemySnakeModel.cs
using UnityEngine;

public class SC_EnemySnakeModel : ConcreteEnemyAnimalModel
{
    public float moveSpeed = 4.0f;
    public float jumpHeight = 2.0f;
    public float jumpDistance = 2.0f;
    public float jumpDuration = 1.0f;
    public float jumpDelay = 0.5f;
    private Vector2 startPosition;
    private float jumpStartTime;
    private bool isJumping;

    private void Start()
    {
        startPosition = transform.position;
        jumpStartTime = Time.time;
        isJumping = false;
    }

    public override void Move()
    {
        base.Move();
        EnemiesMovingMethod.Instance().Frog(ref isJumping, ref jumpStartTime, ref startPosition, transform, jumpDelay, jumpDuration, jumpDistance, jumpHeight, moveSpeed);
    }
}
