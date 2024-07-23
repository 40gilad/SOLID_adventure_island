using UnityEngine;

public class SC_EnemyBirdModel : ConcreteEnemyAnimalModel
{
    //low and height are relative to start position. maxlow FROM START POSITION same as height
    public float moveSpeed = 4.0f;
    public float maxHeight = 4.0f;
    public float maxLow = 0.0f;
    private Vector2 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    public override void Move()
    {
        float newY = startPosition.y + Mathf.PingPong(Time.time * moveSpeed, maxHeight - maxLow) + maxLow;
        float newX = transform.position.x - moveSpeed * Time.deltaTime;
        transform.position = new Vector2(newX, newY);
    }
}
