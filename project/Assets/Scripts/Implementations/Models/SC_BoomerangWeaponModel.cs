using System.Threading.Tasks;
using UnityEngine;

public class SC_BoomerangWeaponModel : ConcreteWeaponModel
{
    public SC_BoomerangWeaponModel()
    {
        prefab_name = "Prefab_BoomerangWeapon";
    }

    protected override void CustomizeShoot(GameObject weapon, float direction)
    {
        _ = ShootingMethods.Instance().ShootBoomerang(weapon, direction,xSpeed,destroyTime);

    }

}


