public class SC_EnemySpiderController : ConcreteEnemyAnimalController
{
    protected override void Init()
    {
        model = gameObject.AddComponent<SC_EnemySpiderModel>();
        model.Initialize(this, damage);

    }
}
