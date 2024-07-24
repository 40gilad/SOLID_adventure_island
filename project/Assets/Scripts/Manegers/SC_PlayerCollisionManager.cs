using Assets.Scripts.Implementations;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class SC_PlayerCollisionManager
{
    private ConcreteUIElementModel UiPower;
    private ConcreteUIElementModel UiLives;
    private SC_Jump jump;
    private bool isCooldown = false;
    private float cooldownTime = 2f;
    public static event Action CoolDownStart;
    public static event Action CoolDownEnd;


    public SC_PlayerCollisionManager(ConcreteUIElementModel _UiPower,
        ConcreteUIElementModel _UiLives, SC_Jump _Jump)
    {
        UiLives = _UiLives;
        UiPower = _UiPower;
        jump = _Jump;
        ConcreteFloor.OnFloorCollision += HandleFloorCollision;

    }

    ~SC_PlayerCollisionManager()
    {
        ConcreteFloor.OnFloorCollision -= HandleFloorCollision;
    }


    public async void HandleCollision(Collider2D other)
    {
        if (isCooldown) return; // Ignore collisions if in cooldown

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
            await CollisionCooldown();
        }
        else if (other.gameObject.CompareTag("WeaponFireBall"))
        {
            int damage = other.gameObject.GetComponent<ConcreteWeaponController>().damage;
            UiLives.Dec(damage);
            await CollisionCooldown();
        }
    }


    private void HandleFloorCollision()
    {
        jump.FloorCollision();
    }
    private void PowerEnemyCollide(int damage = 1)
    {
        UiPower.Dec(damage);
    }

    private void LivesEnemyCollide(int damage = 1)
    {
        Debug.Log("LivesEnemyCollide");
    }

    private async Task CollisionCooldown()
    {
        isCooldown = true;
        CoolDownStart?.Invoke();
        await Task.Delay((int)(cooldownTime * 1000));
        CoolDownEnd?.Invoke();
        isCooldown = false;
    }


}
