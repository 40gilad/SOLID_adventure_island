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
        float newY = startPosition.y + Mathf.PingPong(Time.time * moveSpeed, moveHeight);
        transform.position = new Vector2(startPosition.x, newY);
    }

}
