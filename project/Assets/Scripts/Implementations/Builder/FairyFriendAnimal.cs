using UnityEngine;

public class FairyFriendAnimal : FriendAnimal
{

    private void Start()
    {
        transform.SetParent(GameObject.FindGameObjectWithTag("Player").transform);
        transform.localPosition = new Vector3(-1.5f, 1f, 0f);
    }
    protected override bool CanBeCollected()
    {
        Debug.Log("FairyFriendAnimal CanBeCollected? retuens true");
        return true;
    }

    public override void Attack()
    {
        Debug.Log("Fairy Animal attacks with turn");
    }

    protected override void CombineWithPlayer()
    {
        Debug.Log("Player is now riding Fairy Animal");
    }
}
