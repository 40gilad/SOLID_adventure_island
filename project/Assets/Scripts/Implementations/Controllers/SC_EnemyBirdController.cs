public class SC_EnemyBirdController : ConcreteEnemyAnimalController
{
    protected override void Init()
    {
        model = gameObject.AddComponent<SC_EnemyBirdModel>();
        model.Initialize(this, damage);

    }
}
