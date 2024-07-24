using UnityEngine;

public class GreenFriendAnimalBuilder : IFriendAnimalBuilder
{
    private FriendAnimal animal;

    public GreenFriendAnimalBuilder()
    {
        animal = new GameObject("RedAnimal").AddComponent<GreenFriendAnimal>();
    }

    public void SetColor()
    {
        animal.color = Color.red;
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
