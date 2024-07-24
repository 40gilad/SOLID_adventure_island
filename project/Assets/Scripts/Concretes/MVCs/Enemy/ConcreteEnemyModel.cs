using UnityEngine;

public abstract class ConcreteEnemyModel : SC_EnemyMovement
{
    public int touch_damage;
    protected ConcreteEnemyController controller;

    public void Initialize(ConcreteEnemyController _controller,int damage)
    {
        controller = _controller;
        touch_damage = damage;
    }


    public void WeaponCollider(Collider2D other)
    {
        if (other.gameObject.tag == "WeaponBoomerang")
            BoomerangCollider();
        else if (other.gameObject.tag == "WeaponHammer")
            HammerCollider();
        else if (other.gameObject.tag == "WeaponFireBall")
            FireBallCollider();
    }


    public abstract void PlayerCollider();
    protected abstract void HammerCollider();
    protected abstract void BoomerangCollider();
    protected abstract void FireBallCollider();

    public void WallCollider()
    {
        controller.Died();
    }

}
