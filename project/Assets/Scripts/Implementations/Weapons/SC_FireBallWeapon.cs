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
            UnityEngine.Debug.Log("caught exception in fireball");
        }
    }

    public void FireShoot(float direction, string name)
    {
        _ = model.ShootAsync(direction:direction,obj_name:name);
    }


}
