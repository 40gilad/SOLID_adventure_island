using System.Threading.Tasks;
using UnityEngine;

public class SC_HammerWeaponModel : ConcreteWeaponModel
{
    public SC_HammerWeaponModel()
    {
        prefab_name = "Prefab_HammerWeapon";
    }
    protected override async Task CustomizeShoot(GameObject weapon, float direction)
    {
        await ShootingMethods.Instance().ShootHammer(weapon, direction, xSpeed, destroyTime);

    }
}
