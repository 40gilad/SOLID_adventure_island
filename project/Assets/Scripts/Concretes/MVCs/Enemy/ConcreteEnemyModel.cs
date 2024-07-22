using System;
using UnityEngine;

public abstract class ConcreteEnemyModel : SC_EnemyMovement
{
    public int touch_damage;
    protected ConcreteEnemyController controller;

    protected ConcreteEnemyModel(ConcreteEnemyController _controller)
    {
        controller = _controller;
    }

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
