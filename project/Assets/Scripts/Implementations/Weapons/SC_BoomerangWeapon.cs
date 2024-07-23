using UnityEngine;

public class SC_BoomerangWeapon : ConcreteWeaponController
{
    protected override void Init()
    {
        model = new SC_BoomerangWeaponModel();
        base.Init();
    }

    public override void Shoot(float direction)
    {
        if (UiElement.Get() > 0)
            _ = model.ShootAsync(direction);
    }
}
