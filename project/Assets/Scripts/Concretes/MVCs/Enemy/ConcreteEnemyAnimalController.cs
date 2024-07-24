using UnityEngine;

public abstract class ConcreteEnemyAnimalController : ConcreteEnemyController
{
    private Vector3 initial_position;
    public float revival_time = 5;

    private void Start()
    {
        initial_position = transform.position;
    }
    public override void Died(bool is_wall=false)
    {
        base.Died(is_wall);
        Invoke("BackToLife", revival_time);
    }

    private void BackToLife()
    {
        transform.position = initial_position;
        gameObject.SetActive(true);
    }
}
