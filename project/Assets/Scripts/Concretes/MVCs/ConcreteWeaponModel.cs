using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Xml.Linq;
using UnityEngine;

public abstract class ConcreteWeaponModel
{
    public int damage;
    public string prefab_name;
    public float xSpeed;
    public float ySpeed;
    public float destroyTime;

    public virtual async Task<int> ShootAsync(float direction,string obj_name = "",string tag="Player")
    {
        if (string.IsNullOrEmpty(prefab_name))
            throw new NullReferenceException("prefab_name need to initialize in derrived class");

        GameObject weapon = PoolManager.Instance.GetObjectFromPool(prefab_name);
        if (weapon == null)
            throw new InvalidOperationException("Weapon object could not be retrieved from the pool.");
        if (obj_name != "")
            weapon.transform.position = GameObject.Find(obj_name).transform.position;
        else
            weapon.transform.position = GameObject.FindGameObjectWithTag(tag).transform.position;

        await CustomizeShoot(weapon, direction);
        PoolManager.Instance.ReturnObjectToPool(weapon);

        return damage;
    }

    protected virtual async Task CustomizeShoot(GameObject weapon, float direction)
    {
        await ShootingMethods.Instance().ShootBasic(weapon,direction,xSpeed,destroyTime);
    }

}
