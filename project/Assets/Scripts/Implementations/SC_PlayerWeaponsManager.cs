using UnityEngine;

public class SC_PlayerWeaponsManager : MonoBehaviour
{
    public ConcreteWeaponController boomerang_weapon;
    public ConcreteWeaponController hammer_weapon;
    private ConcreteWeaponController curr;
    void Update()
    {
        curr = null;
        if (Input.GetKeyDown(KeyCode.B))
            curr = boomerang_weapon;
        else if (Input.GetKeyDown(KeyCode.H))
            curr = hammer_weapon;


        if (curr != null)
        {
            float direction = GameObject.FindGameObjectWithTag("Player").transform.localScale.x;
            curr.Shoot();
        }
    }

}
