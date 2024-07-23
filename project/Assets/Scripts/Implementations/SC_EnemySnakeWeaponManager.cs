using UnityEngine;

public class SC_EnemySnakeWeaponManager : MonoBehaviour
{
    public ConcreteWeaponController fireball;


    void Update()
    {
        float direction = GameObject.FindGameObjectWithTag("Player").transform.localScale.x;
        fireball.Shoot(direction);
    }

}
