using System.Drawing;
using UnityEngine;

public class FairyFriendAnimal : FriendAnimal
{
    GameObject player;
    private string color = "Fairy";
    private void Start()
    {
        GameObject.Find("Cards_FriendAnimalsManager").
            GetComponent<Cards_FriendsAnimalsManaeger>().SetAnimal("Fairy");
    }

    public override void Attack()
    {
        Debug.Log("Fairy Animal attacks with turn");
    }


    protected override void PlayerCollider(Collider2D other)
    {//nothing kills fairy
    }

}
