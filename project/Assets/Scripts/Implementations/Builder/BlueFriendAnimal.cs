using UnityEngine;

public class BlueFriendAnimal : FriendAnimal
{

    protected override bool CanBeCollected()
    {
        Debug.Log("BlueFriendAnimal CanBeCollected? retuens true");
        return true;
    }

    protected override void Attack()
    {
        Debug.Log("Blue Animal attacks with tail");
    }

    protected override void CombineWithPlayer()
    {
        Debug.Log("Player is now riding Blue Animal");
    }
}
