using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class ShootingMethods
{

    private static ShootingMethods _instance;
    private ShootingMethods()
    {
    }

    public static ShootingMethods Instance()
    {
        if (_instance == null)
            _instance = new ShootingMethods();
        return _instance;
    }


    public async Task ShootBoomerang(GameObject weapon, float direction,
        float xSpeed, float destroyTime)
    {
        Vector3 startPosition = weapon.transform.position;
        Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        // Rotation speed in degrees per second
        float rotationSpeed = 360f;

        // Move to the right along the x-axis
        rb.velocity = new Vector2(xSpeed * direction, 0);
        float travelTime = destroyTime / 2;

        // Start the movement and rotation
        float elapsedTime = 0f;
        while (elapsedTime < travelTime)
        {
            weapon.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            await Task.Yield();
        }

        // Move back to the original position
        rb.velocity = new Vector2(-xSpeed * direction, 0);

        // Continue the movement and rotation
        elapsedTime = 0f;
        while (elapsedTime < travelTime)
        {
            weapon.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            await Task.Yield();
        }

    }

    public async Task ShootBasic(GameObject weapon, float direction,
    float xSpeed, float destroyTime)
    {

        Debug.Log("SHOOT METHODS: Shoot Basic");

    }

    public async Task ShootHammer(GameObject weapon, float direction,
float xSpeed, float destroyTime)
    {

        Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(xSpeed * direction, 0);

        float elapsedTime = 0;
        while (elapsedTime < destroyTime)
        {
            weapon.transform.Rotate(0, 0, 1);
            elapsedTime += Time.deltaTime;
            await Task.Yield();
        }

    }
}
