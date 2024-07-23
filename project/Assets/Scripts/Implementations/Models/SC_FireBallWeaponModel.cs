using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class SC_FireBallWeaponModel : ConcreteWeaponModel
{
    public SC_FireBallWeaponModel()
    {
        prefab_name = "Prefab_FireBallWeapon";
    }

    protected override async Task CustomizeShoot(GameObject weapon, float direction)
    {
        await ShootingMethods.Instance().ShootBasic(weapon, direction, xSpeed, destroyTime);
    }

}


