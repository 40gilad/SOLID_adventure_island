using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_CameraFollows : MonoBehaviour
{
    public Transform player;
    public float minY; 
    public float minX;

    void Update()
    {
        Vector3 newPosition = transform.position;

        if (player.position.y > minY)
        {
            newPosition.y = player.position.y;
        }
        else
        {
            newPosition.y = minY;
        }

        if (player.position.x > minX)
        {
            newPosition.x = player.position.x;
        }
        else
        {
            newPosition.x = minX;
        }

        transform.position = newPosition;
    }
}
