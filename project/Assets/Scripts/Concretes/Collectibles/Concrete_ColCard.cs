using System;
using UnityEngine;

public class Concrete_ColCard : ConcreteCollectible
{
    public int effect;
    protected string animal_color;
    private Cards_FriendsAnimalsManaeger cards_manager;
    protected override void Init()
    {
        cards_manager = GameObject.Find("Cards_FriendAnimalsManager").
            GetComponent<Cards_FriendsAnimalsManaeger>();
    }
    public override void OnCollect()
    {
        Debug.Log("Animal " + animal_color);
        cards_manager.SetAnimal(animal_color);
    }
}
