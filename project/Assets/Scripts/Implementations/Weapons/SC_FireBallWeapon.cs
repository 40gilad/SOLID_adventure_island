using System;
using UnityEngine;
using System.Diagnostics;

public class SC_FireBallWeapon : ConcreteWeaponController
{
    protected override void Init()
    {
        model = new SC_FireBallWeaponModel();
        try
        {
            base.Init();
        }
        catch (NullReferenceException)
        {
        }
    }

    public void FireShoot(float direction, string name)
    {
        _ = model.ShootAsync(direction:direction,obj_name:name);
    }


}
