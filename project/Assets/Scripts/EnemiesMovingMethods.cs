using UnityEngine;

public class EnemiesMovingMethod : MonoBehaviour
{
    private static EnemiesMovingMethod _instance;
    private EnemiesMovingMethod()
    {
    }

    public static EnemiesMovingMethod Instance()
    {
        if (_instance == null)
            _instance = new EnemiesMovingMethod();
        return _instance;
    }

    public void Frog(bool isJumping, float jumpStartTime, Vector2 startPosition, Transform transform,
        float jumpDelay = 0.5f, float jumpDuration = 1.0f, float jumpDistance = 4.0f,
        float jumpHeight = 3.0f,float moveSpeed = 4.0f)
    {
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
