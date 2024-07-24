using UnityEngine;

public class RedFriendAnimalBuilder : IFriendAnimalBuilder
{
    private FriendAnimal animal;

    public RedFriendAnimalBuilder()
    {
        animal = new GameObject("RedAnimal").AddComponent<RedFriendAnimal>();
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
