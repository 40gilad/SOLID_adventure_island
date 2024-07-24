using UnityEngine;

public class BlueFriendAnimal : FriendAnimal
{


    public override void Attack()
    {
        Debug.Log("Blue Animal attacks with tail");
    }

    protected override void CombineWithPlayer()
    {
        Debug.Log("Player is now riding Blue Animal");
    }
}
