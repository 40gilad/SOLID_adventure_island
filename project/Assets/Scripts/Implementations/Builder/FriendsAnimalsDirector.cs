public class FriendsAnimalsDirector
{
    private IFriendAnimalBuilder builder;

    public FriendsAnimalsDirector(IFriendAnimalBuilder builder)
    {
        this.builder = builder;
    }

    public void Construct()
    {
        builder.SetColor();
        builder.SetCollectible();
        builder.SetAttackBehavior();
    }

    public FriendAnimal GetAnimal()
    {
        return builder.GetAnimal();
    }
}
