using System;

using UnityEngine;

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
            Debug.Log("caught exception in fireball");
        }
    }

    public override void Shoot(float direction)
    {
            _ = model.ShootAsync(direction,"Snake");
    }

}
