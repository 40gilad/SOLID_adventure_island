using UnityEngine;

public class RedFriendAnimal : FriendAnimal
{
    private SC_PlayerFireBallWeapon fireball_weapon;


    private void Start()
    {
        fireball_weapon = GameObject.Find("SC_PlayerFireBallWeapon").GetComponent<SC_PlayerFireBallWeapon>();
    }
    public override void Attack()
    {
        float direction = GameObject.FindGameObjectWithTag("Player").transform.localScale.x;
        fireball_weapon.FireShoot(direction,name);
    }
}
