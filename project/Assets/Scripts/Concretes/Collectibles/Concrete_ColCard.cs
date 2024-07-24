using System;
using UnityEngine;

public class Concrete_ColCard : ConcreteCollectible
{
    public int effect;
    protected string animal_color;
    public GameObject cards_friendsAnimalsManager;
    private Cards_FriendsAnimalsManaeger game_manager;
    protected override void Init()
    {
        game_manager = cards_friendsAnimalsManager.GetComponent<Cards_FriendsAnimalsManaeger>();
    }
    public override void OnCollect()
    {
        Debug.Log("Animal " + animal_color);
        game_manager.SetAnimal(animal_color);
    }
}
