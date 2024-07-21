using Assets.Scripts.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerController : SC_PlayerMovement
{

    private SC_Jump jump;

    private void Start()
    {
        jump = new SC_Jump(jump_speed, rigid);
    }

    public override void Move()
    {
        base.Move();
        if (Input.GetKeyDown(KeyCode.Space))
            jump.Jump();

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
