using UnityEngine;

public abstract class ConcreteEnemyAnimalController : ConcreteEnemyController
{
    private Vector3 initial_position;
    public float revival_time = 5;

    private void Start()
    {
        initial_position = transform.position;
    }
    public override void Died()
    {
        gameObject.SetActive(false);
        Invoke("BackToLife", revival_time);
        //lay eggs sometimes
    }

    private void BackToLife()
    {
        transform.position = initial_position;
        gameObject.SetActive(true);
    }
}
