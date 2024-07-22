using System.Threading.Tasks;
using UnityEngine;

public class SC_BoomerangWeaponModel : ConcreteWeaponModel
{
    public SC_BoomerangWeaponModel()
    {
        prefab_name = "Prefab_BoomerangWeapon";
    }

    protected override async Task CustomizeShoot(GameObject weapon, float direction)
    {
        await ShootingMethods.Instance().ShootBoomerang(weapon, direction,xSpeed,destroyTime);

    }

}


