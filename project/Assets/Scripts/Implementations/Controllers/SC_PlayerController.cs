using Assets.Scripts.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerController : SC_PlayerMovement
{

    private SC_Jump jump;
    private SC_PlayerCollisionManager collider_manager;
    public string PowerUiElementName;
    public string LivesUiElementsName;

    private void Start()
    {
        ConcreteUIElementModel UiPower=null;
        ConcreteUIElementModel UiLives=null;
        jump = new SC_Jump(jump_speed, rigid);
        ConcreteUIElementController tempController = GameObject.Find(PowerUiElementName).GetComponent<ConcreteUIElementController>();
        if (tempController != null )
            UiPower = tempController.model;
        tempController = GameObject.Find(LivesUiElementsName).GetComponent<ConcreteUIElementController>();
        if (tempController != null )
            UiLives = tempController.model;
        collider_manager = new SC_PlayerCollisionManager(UiPower, UiLives,jump);
    }

    public override void Move()
    {
        base.Move();
        if (Input.GetKeyDown(KeyCode.Space))
            jump.Jump();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        collider_manager.HandleCollision(other);
    }

}
