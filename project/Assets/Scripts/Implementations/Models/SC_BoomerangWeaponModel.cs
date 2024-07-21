using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_BoomerangWeaponModel : ConcreteWeaponModel
{

    public override void Shoot(int effect = 1)
    {
        base.Shoot(effect);
        Debug.Log("Boomerang Shoot");
    }

}
