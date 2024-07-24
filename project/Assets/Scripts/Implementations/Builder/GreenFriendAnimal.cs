using UnityEngine;

public class GreenFriendAnimal : FriendAnimal
{
    void Start()
    {
        color = Color.red;
    }

    protected override bool CanBeCollected()
    {
        Debug.Log("GreenFriendAnimal CanBeCollected? retuens true");
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
