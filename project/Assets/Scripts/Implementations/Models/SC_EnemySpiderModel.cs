
public class SC_EnemySpiderModel : ConcreteEnemyAnimalModel
{
    public SC_EnemySpiderModel(ConcreteEnemyController c, int d) : base(c, d)
    {
    }
    private void Update()
    {
        Move();
    }
}
