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
        else if (other.gameObject.tag == "PlayerWeaponFireBall")
            PlayerFireBallCollider();
    }


    public virtual void PlayerCollider(Collider2D other)
    {
        string friend_enemy_color= other.GetComponent<SC_PlayerWeaponsManager>().
            GetFriendAnimal();
        if (friend_enemy_color != null)
        {//one of the FriendsAnimal
            if (friend_enemy_color == "Fairy")
                PlayerFairyCollider();
            else
                PlayerFriendEnemyCollider(other.GetComponent<SC_PlayerWeaponsManager>().IsAnimalAttacking());
        }

    }
    protected virtual void HammerCollider()
    {
        controller.Died();
    }
    protected virtual void BoomerangCollider()
    {
        controller.Died();
    }
    protected virtual void PlayerFireBallCollider()
    {
        controller.Died();
    }
    private void PlayerFairyCollider()
    {
        controller.Died();
    }

    protected virtual void PlayerFriendEnemyCollider(bool is_friendAnimal_attacking)
    {
        controller.Died();
    }

    public void WallCollider()
    {
        controller.Died(is_wall:true);
    }

}
