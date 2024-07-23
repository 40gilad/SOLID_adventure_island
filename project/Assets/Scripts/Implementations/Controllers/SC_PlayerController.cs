using Assets.Scripts.Implementations;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class SC_PlayerController : SC_PlayerMovement
{

    private SC_Jump jump;
    private SC_PlayerCollisionManager collider_manager;
    public string PowerUiElementName;
    public string LivesUiElementsName;
    private SpriteRenderer spriteRenderer;
    private bool isBlinking = false;
    private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();


    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        ConcreteUIElementModel UiPower =null;
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

    private void OnEnable()
    {
        SC_PlayerCollisionManager.CoolDownStart += StartCoolDown;
        SC_PlayerCollisionManager.CoolDownEnd += EndCoolDown;
    }


    private void OnDisable()
    {
        SC_PlayerCollisionManager.CoolDownStart -= StartCoolDown;
        SC_PlayerCollisionManager.CoolDownEnd -= EndCoolDown;
        cancellationTokenSource.Cancel();

    }

    private void StartCoolDown()
    {
        if (!isBlinking)
        {
            isBlinking = true;
            StartBlinking(cancellationTokenSource.Token);
        }
    }

    private void EndCoolDown()
    {
        isBlinking = false;
        spriteRenderer.enabled = true;
    }

    private async void StartBlinking(CancellationToken token)
    {
        while (isBlinking)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            try
            {
                await Task.Delay(100, token);
            }
            catch (TaskCanceledException)
            {
                break; 
            }
        }
    }
}
