using System.Threading.Tasks;
using UnityEngine;

public class SC_BoomerangWeaponModel : ConcreteWeaponModel
{
    public SC_BoomerangWeaponModel()
    {
        prefab_name = "Prefab_BoomerangWeapon";
    }

    protected override void CustomizeShoot(GameObject weapon, float direction)
    {
        //need to be deliverd from playerManagerWeapons:
        Transform playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        weapon.transform.position = playerTransform.position;
        _ = ReturnBoomerangAsync(weapon, direction);

    }

    private async Task ReturnBoomerangAsync(GameObject weapon, float direction)
    {
        await Task.Delay((int)(destroyTime / 2 * 1000));

        Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();
        rb.velocity = Vector2.zero;
        rb.AddForce(new Vector2(-xSpeed * direction, ySpeed));

        await Task.Delay((int)(destroyTime / 2 * 1000));

        PoolManager.Instance.ReturnObjectToPool(weapon);
    }
}

