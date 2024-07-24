using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerFireBallWeapon : ConcreteWeaponController
{
    protected override void Init()
    {
        model = new SC_PlayerFireBallWeaponModel();
        try
        {
            base.Init();
        }
        catch (NullReferenceException)
        {
        }
    }

    public void FireShoot(float direction,string name)
    {
        _ = model.ShootAsync(direction: direction,obj_name:name);
    }
}
