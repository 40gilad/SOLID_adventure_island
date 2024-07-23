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
        float elapsedTime = Time.time - jumpStartTime;
        if (isJumping)
        {
            if (elapsedTime >= jumpDuration)
            {
                isJumping = false;
                jumpStartTime = Time.time;
            }
            else
            {
                float normalizedTime = elapsedTime / jumpDuration;

                // Parabolic movement for the jump
                float newY = startPosition.y + jumpHeight * Mathf.Sin(Mathf.PI * normalizedTime);
                float newX = startPosition.x - (jumpDistance / jumpDuration) * elapsedTime;

                transform.position = new Vector2(newX, newY);
            }
        }
        else
        {
            if (elapsedTime >= jumpDelay)
            {
                isJumping = true;
                jumpStartTime = Time.time;
                startPosition = transform.position;
            }
        }
    }
}
