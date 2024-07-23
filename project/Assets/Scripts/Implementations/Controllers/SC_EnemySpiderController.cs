public class SC_EnemySpiderController : ConcreteEnemyAnimalController
{
    protected override void Init()
    {
        model = new SC_EnemySpiderModel(this, damage);
    }
}
