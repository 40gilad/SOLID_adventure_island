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

    protected override void CombineWithPlayer()
    {
        Debug.Log("Player is now riding Blue Animal");
    }
}
