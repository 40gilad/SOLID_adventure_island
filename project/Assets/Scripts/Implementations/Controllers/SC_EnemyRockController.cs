

public class SC_EnemyRockController : ConcreteEnemyController
{
    protected override void Init()
    {
        model = gameObject.AddComponent<SC_EnemyRockModel>();
        model.Initialize(this,damage);
    }
}
