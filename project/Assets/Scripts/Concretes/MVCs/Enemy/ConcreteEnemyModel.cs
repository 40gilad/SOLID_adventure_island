using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConcreteEnemyModel : SC_EnemyMovement
{
    public int touch_damage;
    public bool is_lives_weapon;

    private void Start()
    {
        is_moving = false;
    }

    public void WeaponCollider(Collider2D other)
    {
        if (other.gameObject.tag == "WeaponBoomerang")
            BoomerangCollider();
        else if (other.gameObject.tag == "WeaponHammer")
            HammerCollider();
    }

    public abstract void PlayerCollider();

    protected abstract void HammerCollider();

    protected abstract void BoomerangCollider();
}
