using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BoomerangWeaponModel : ConcreteWeaponModel
{
    private string prefab_name = "Prefab_BoomerangWeapon";
    public override void Shoot(int effect = 1)
    {
        base.Shoot(effect);
        GameObject boomerang = PoolManager.Instance.GetObjectFromPool(prefab_name);
        boomerang.transform.position = new Vector3(1, 2, 0);
        Debug.Log("Boomerang Shoot");

    }

}
