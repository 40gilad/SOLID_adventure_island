using UnityEngine;

public class SC_EnemySnakeWeaponManager : MonoBehaviour
{
    private SC_FireBallWeapon fireball;
    private float shotInterval = 1.0f;
    private float nextShotTime = 0f;
    public float shootDistance = 5.0f;


    private void Start()
    {
        fireball = GameObject.Find("SC_FireBallWeapon").GetComponent<SC_FireBallWeapon>();

    }
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float distanceToPlayer = Mathf.Abs(player.transform.position.x - transform.position.x);
        if (distanceToPlayer <= shootDistance)
        {
            if (Time.time >= nextShotTime)
            {
                float direction = Mathf.Sign(player.transform.position.x - transform.position.x);
                fireball.FireShoot(direction, name);
                nextShotTime = Time.time + shotInterval;
            }
        }
    }
}
