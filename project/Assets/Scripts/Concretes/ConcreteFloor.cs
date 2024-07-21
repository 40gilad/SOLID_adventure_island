using System;
using UnityEngine;

public class ConcreteFloor : MonoBehaviour
{
    public static event Action OnFloorCollision;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
            OnFloorCollision?.Invoke();
    }
}
