using Assets.Scripts.Implementations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerCollisionManager {
    private ConcreteUIElementModel UiPower;
    private ConcreteUIElementModel UiLives;
    private SC_Jump jump;


    public SC_PlayerCollisionManager(ConcreteUIElementModel _UiPower,
        ConcreteUIElementModel _UiLives, SC_Jump _Jump)
    {
        UiLives = _UiLives;
        UiPower = _UiPower;
        jump = _Jump;
    }
    public void HandleCollision(Collider2D other)
    {
        if (other.gameObject.tag.StartsWith("Enemy"))
        {
            int damage = other.gameObject.GetComponent<ConcreteEnemyController>().damage;
            string tag = other.gameObject.tag;
            switch (tag)
            {
                case "EnemyPower":
                    PowerEnemyCollide(damage);
                    break;
                case "EnemyLives":
                    LivesEnemyCollide(damage);
                    break;
                default: break;
            }
        }
        else if (other.gameObject.CompareTag("WeaponFireBall"))
        {
            int damage = other.gameObject.GetComponent<ConcreteWeaponController>().damage;
            UiLives.Dec(damage);
        }
    }

    private void PowerEnemyCollide(int damage = 1)
    {
        UiPower.Dec(damage);
    }

    private void LivesEnemyCollide(int damage = 1)
    {
        Debug.Log("LivesEnemyCollide");
    }

    private void OnEnable()
    {
        ConcreteFloor.OnFloorCollision += HandleFloorCollision;
    }

    private void OnDisable()
    {
        ConcreteFloor.OnFloorCollision -= HandleFloorCollision;
    }

    private void HandleFloorCollision()
    {
        jump.FloorCollision();
    }

}
