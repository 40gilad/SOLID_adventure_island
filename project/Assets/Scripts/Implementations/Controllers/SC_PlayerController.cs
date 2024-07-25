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
    private SC_PlayerWeaponsManager weapon_manager;
    public string PowerUiElementName;
    public string LivesUiElementsName;
    private SpriteRenderer spriteRenderer;
    private bool isBlinking = false;
    private CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();
    private Vector3 initial_position;
    public static event Action GameOver;


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
        initial_position = transform.position;
        weapon_manager= GetComponent<SC_PlayerWeaponsManager>();
    }

    public override void Move()
    {
        base.Move();
        if (Input.GetKeyDown(KeyCode.Space))
            jump.Jump();

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        bool is_animal_attacking = weapon_manager.IsAnimalAttacking();
        collider_manager.HandleCollision(other,is_animal_attacking,weapon_manager.GetColor());
    }

    private void OnEnable()
    {
        SC_PlayerCollisionManager.GoToStart += GoToStart;
        SC_PlayerCollisionManager.CoolDownStart += StartCoolDown;
        SC_PlayerCollisionManager.CoolDownEnd += EndCoolDown;
    }


    private void OnDisable()
    {
        SC_PlayerCollisionManager.GoToStart -= GoToStart;
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

    private void GoToStart(int lives)
    {
        if (lives < 0)
        {
            GameOver?.Invoke();
            return;
        }
        transform.position = initial_position;
    }
}
