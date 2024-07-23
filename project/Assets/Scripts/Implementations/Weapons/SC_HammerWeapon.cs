using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_HammerWeapon : ConcreteWeaponController
{
    protected override void Init()
    {
        model = new SC_HammerWeaponModel();
        base.Init();
    }

    public override void Shoot(float direction)
    {
        if (UiElement.Get() > 0)
        {
            _ = model.ShootAsync(direction);
            UiElement.Dec();
            view.UIUpdate(UiElement.Get());
        }
    }

}
