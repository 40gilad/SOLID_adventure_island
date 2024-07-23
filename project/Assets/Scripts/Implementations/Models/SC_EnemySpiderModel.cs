using UnityEngine;

public class SC_EnemySpiderModel : ConcreteEnemyAnimalModel
{
    public float moveSpeed = 2.0f;
    private float moveHeight = 9.0f;
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }
    public override void Move()
    {
        base.Move();
        EnemiesMovingMethod.Instance().Spider(transform, startPosition, moveSpeed, moveHeight);

    }

}
