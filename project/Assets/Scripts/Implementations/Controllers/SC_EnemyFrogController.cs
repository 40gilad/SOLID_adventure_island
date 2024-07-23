public class SC_EnemyFrogController : ConcreteEnemyAnimalController
{
    protected override void Init()
    {
        model = gameObject.AddComponent<SC_EnemyFrogModel>();
        model.Initialize(this, damage);

    }
}
