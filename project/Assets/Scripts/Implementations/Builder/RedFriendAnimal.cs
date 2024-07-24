using UnityEngine;

public class RedFriendAnimal : FriendAnimal
{

    protected override bool CanBeCollected()
    {
        Debug.Log("RedFriendAnimal CanBeCollected? retuens true");
        return true;
    }

    public override void Attack()
    {
        Debug.Log("Red Animal shoot fire");
    }

    protected override void CombineWithPlayer()
    {
        Debug.Log("Player is now riding Blue Animal");
    }
}
