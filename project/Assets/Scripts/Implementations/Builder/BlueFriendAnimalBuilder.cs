using UnityEngine;

public class BlueFriendAnimalBuilder : IFriendAnimalBuilder
{
    private FriendAnimal animal;

    public BlueFriendAnimalBuilder()
    {
        animal = new GameObject("RedAnimal").AddComponent<BlueFriendAnimal>();
    }


    public void SetCollectible()
    {
        // Set collectible specific to Red Animal
    }

    public void SetAttackBehavior()
    {
        // Set attack behavior specific to Red Animal
    }

    public FriendAnimal GetAnimal()
    {
        return animal;
    }
}
