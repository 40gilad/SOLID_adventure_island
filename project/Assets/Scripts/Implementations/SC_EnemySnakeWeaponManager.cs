using UnityEngine;

public class SC_EnemySnakeWeaponManager : MonoBehaviour
{
    public SC_FireBallWeapon fireball;
    private float shotInterval = 1.0f;
    private float nextShotTime = 0f;

    void Update()
    {
        if (Time.time >= nextShotTime)
        {
            float direction = Mathf.Sign(GameObject.FindGameObjectWithTag("Player").transform.position.x - transform.position.x);
            fireball.FireShoot(direction,name);
            nextShotTime = Time.time + shotInterval;
        }
    }
}
