using UnityEngine;

public class FairyFriendAnimalBuilder : IFriendAnimalBuilder
{
    private FriendAnimal animal;

    public FairyFriendAnimalBuilder()
    {
        animal = new GameObject("FairyAnimal").AddComponent<FairyFriendAnimal>();
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
