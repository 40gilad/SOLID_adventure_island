using UnityEngine;

public class SC_EnemySnakeWeaponManager : MonoBehaviour
{
    public ConcreteWeaponController fireball;
    private float shotInterval = 1.0f;
    private float nextShotTime = 0f;

    void Update()
    {
        if (Time.time >= nextShotTime)
        {
            float direction = Mathf.Sign(GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x);
            fireball.Shoot(direction);
            nextShotTime = Time.time + shotInterval;
        }
    }
}
