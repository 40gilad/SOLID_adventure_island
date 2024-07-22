using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_HammerWeaponModel : ConcreteWeaponModel
{
    public SC_HammerWeaponModel()
    {
        prefab_name = "Prefab_HammerWeapon";
    }

    protected override void CustomizeShoot(GameObject weapon, float direction)
    {
        throw new System.NotImplementedException();
    }
}
