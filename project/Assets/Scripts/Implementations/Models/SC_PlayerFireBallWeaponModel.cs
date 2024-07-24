using UnityEngine;
using System.Threading.Tasks;


public class SC_PlayerFireBallWeaponModel : ConcreteWeaponModel
{
    public SC_PlayerFireBallWeaponModel()
    {
        prefab_name = "Prefab_PlayerFireBallWeapon";
    }

    protected override async Task CustomizeShoot(GameObject weapon, float direction)
    {
        await ShootingMethods.Instance().ShootBasic(weapon, direction, xSpeed, destroyTime);
    }

}

