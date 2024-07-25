using UnityEngine;

public class GreenFriendAnimal : FriendAnimal
{

    public override void Attack()
    {
        player_weapon_manager.is_animal_attacking = true;
        ChangeSprite();
        Invoke("RevertSprite", 0.5f);
        player_weapon_manager.is_animal_attacking = false;

    }

}
