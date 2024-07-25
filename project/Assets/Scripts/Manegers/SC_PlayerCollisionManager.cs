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
    public static event Action PlayerCollideCave;
    public static event Action<int> GoToStart;


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


    public async void HandleCollision(Collider2D other,bool is_animal_attacking,string animal_color)
    {
        if (isCooldown) return; // Ignore collisions if in cooldown

        if (other.gameObject.tag.StartsWith("Enemy"))
        {
            int damage = other.gameObject.GetComponent<ConcreteEnemyController>().damage;
            string tag = other.gameObject.tag;
            if (other.gameObject.name.StartsWith("Prefab_EnemyGhost")
                && !GhostCollide(animal_color))
                return;
            else if (is_animal_attacking)
                return;
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

        else if (other.gameObject.CompareTag("Depth"))
            LivesEnemyCollide();

        else if (other.gameObject.CompareTag("WeaponFireBall"))
        {
            int damage = other.gameObject.GetComponent<ConcreteWeaponController>().damage;
            UiLives.Dec(damage);
            await CollisionCooldown();
        }

        else if (other.gameObject.CompareTag("Cave"))
            CaveCollide();

    }


    private void HandleFloorCollision()
    {
        jump.FloorCollision();
    }
    private void PowerEnemyCollide(int damage = 1)
    {
        UiPower.Dec(damage);
    }
    private bool GhostCollide(string animal_color)
    {
        if (animal_color == "Fairy")
            return false;
        return true;

    }

    private void CaveCollide()
    {
        Debug.Log("Player Collide in cave");
        PlayerCollideCave?.Invoke();
    }

    private void LivesEnemyCollide(int damage = 1)
    {
        UiLives.Dec(damage);
        GoToStart?.Invoke(UiLives.Get());
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
