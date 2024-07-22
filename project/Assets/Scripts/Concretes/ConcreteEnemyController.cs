using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ConcreteEnemyController : SC_EnemyMovement
{
    public int touch_damage;
    public bool is_lives_weapon;

    private void Start()
    {
        is_moving = false;
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player") // player collider touch 'my_collider'
            PlayerCollide();
        else if (other.gameObject.tag.StartsWith("Weapon"))
            WeaponCollide(other);
    }

    private void WeaponCollide(Collider2D other)
    {
        if (other.gameObject.tag == "WeaponBoomerang")
            BoomerangCollide();
        else if (other.gameObject.tag == "WeaponHammer")
            HammerCollide();
    }

    protected abstract void PlayerCollide();

    protected abstract void HammerCollide();

    protected abstract void BoomerangCollide();
}
