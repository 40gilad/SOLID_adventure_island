using UnityEngine;

public class SC_PlayerWeaponsManager : MonoBehaviour
{
    public ConcreteWeaponController boomerang_weapon;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
            if (boomerang_weapon != null)
            {
                float direction = GameObject.FindGameObjectWithTag("Player").transform.localScale.x;
                boomerang_weapon.Shoot();
            }
    }

}
