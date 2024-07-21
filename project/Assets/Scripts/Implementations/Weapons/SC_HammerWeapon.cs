using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_HammerWeapon : ConcreteWeaponController
{
    protected override void Init()
    {
        base.Init();
        model = new SC_HammerWeaponModel();
    }
}
