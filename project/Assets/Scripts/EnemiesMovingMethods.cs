using System;
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
            _instance = new GameObject("EnemiesMovingMethod").AddComponent<EnemiesMovingMethod>();
        return _instance;
    }

     public void Frog(ref bool isJumping, ref float jumpStartTime, ref Vector2 startPosition, Transform transform,
        float jumpDelay = 0.5f, float jumpDuration = 1.0f, float jumpDistance = 4.0f, float jumpHeight = 3.0f, float moveSpeed = 4.0f)
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

    public void Spider(Transform transform, Vector2 startPosition, float moveSpeed = 2.0f, float moveHeight = 9.0f)
    {
        float newY = startPosition.y + Mathf.PingPong(Time.time * moveSpeed, moveHeight);
        transform.position = new Vector2(startPosition.x, newY);
    }

    public void Bird(Transform transform, Vector2 startPosition, float moveSpeed = 4.0f, float maxHeight = 4.0f, float maxLow = 0.0f)
    {
        float newY = startPosition.y + Mathf.PingPong(Time.time * moveSpeed, maxHeight - maxLow) + maxLow;
        float newX = transform.position.x - moveSpeed * Time.deltaTime;
        transform.position = new Vector2(newX, newY);
    }

    public void Basic(Transform transform, ref Transform playerTransform)
    {
        try
        {
            if (playerTransform == null)
                playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

            if (playerTransform.position.x > transform.position.x && transform.localScale.x > 0)
                Flip(transform);
            else if (playerTransform.position.x < transform.position.x && transform.localScale.x < 0)
                Flip(transform);
        }
        catch (NullReferenceException)
        {
            playerTransform = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
    }

    private void Flip(Transform transform)
    {
        Vector3 scale = transform.localScale;
        scale.x *= -1; // Flip the x scale to change direction
        transform.localScale = scale;
    }
}
