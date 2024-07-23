using Assets.Scripts.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerController : SC_PlayerMovement
{

    private SC_Jump jump;
    public string PowerUiElementName;
    public string LivesUiElementsName;
    private ConcreteUIElementModel UiPower;
    private ConcreteUIElementModel UiLives;


    private void Start()
    {
        jump = new SC_Jump(jump_speed, rigid);
        ConcreteUIElementController tempController = GameObject.Find(PowerUiElementName).GetComponent<ConcreteUIElementController>();
        if (tempController != null )
            UiPower = tempController.model;
        tempController = GameObject.Find(LivesUiElementsName).GetComponent<ConcreteUIElementController>();
        if (tempController != null )
            UiLives = tempController.model;

    }

    public override void Move()
    {
        base.Move();
        if (Input.GetKeyDown(KeyCode.Space))
            jump.Jump();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag.StartsWith("Enemy"))
        {
            int damage = other.gameObject.GetComponent<ConcreteEnemyController>().damage;
            string tag = other.gameObject.tag;
            switch (tag) {
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

    private void PowerEnemyCollide(int damage=1)
    {
        UiPower.Dec(damage);
    }

    private void LivesEnemyCollide(int damage=1)
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
