using UnityEngine;

public class BlueFriendAnimal : FriendAnimal
{


    public override void Attack()
    {
        ChangeSprite();
        Invoke("RevertSprite", 0.5f);
    }

    protected override void CombineWithPlayer()
    {
        Debug.Log("Player is now riding Blue Animal");
    }
}
