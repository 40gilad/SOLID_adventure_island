public class SC_EnemySnakeController : ConcreteEnemyAnimalController
{
    protected override void Init()
    {
        model = gameObject.AddComponent<SC_EnemySnakeModel>();
        model.Initialize(this, damage);
    }
}
