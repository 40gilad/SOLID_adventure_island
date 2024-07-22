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
        _ = ShootBoomerang(weapon, direction);

    }

    private async Task ShootBoomerang(GameObject weapon, float direction)
    {
        Vector3 startPosition = weapon.transform.position;
        Rigidbody2D rb = weapon.GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.FreezePositionY;
        // Rotation speed in degrees per second
        float rotationSpeed = 360f;

        // Move to the right along the x-axis
        rb.velocity = new Vector2(xSpeed * direction, 0);
        float travelTime = destroyTime / 2;

        // Start the movement and rotation
        float elapsedTime = 0f;
        while (elapsedTime < travelTime)
        {
            weapon.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            await Task.Yield();
        }

        // Move back to the original position
        rb.velocity = new Vector2(-xSpeed * direction, 0);

        // Continue the movement and rotation
        elapsedTime = 0f;
        while (elapsedTime < travelTime)
        {
            weapon.transform.Rotate(0, 0, rotationSpeed * Time.deltaTime);
            elapsedTime += Time.deltaTime;
            await Task.Yield();
        }

        // Stop and return the weapon to the pool
        rb.velocity = Vector2.zero;
        PoolManager.Instance.ReturnObjectToPool(weapon);
    }
}


