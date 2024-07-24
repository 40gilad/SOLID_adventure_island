using UnityEngine;

public class GreenFriendAnimal : FriendAnimal
{

    protected override bool CanBeCollected()
    {
        Debug.Log("GreenFriendAnimal CanBeCollected? retuens true");
        return true;
    }

    public override void Attack()
    {
        Debug.Log("Green Animal attacks with turn");
    }

    protected override void CombineWithPlayer()
    {
        Debug.Log("Player is now riding Blue Animal");
    }
}
