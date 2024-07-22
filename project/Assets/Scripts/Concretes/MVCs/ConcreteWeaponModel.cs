using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public abstract class ConcreteWeaponModel
{
    public int damage;
    public string prefab_name;
    public float xSpeed;
    public float ySpeed;
    public float destroyTime;

    public virtual int Shoot(float direction)
    {
        if (string.IsNullOrEmpty(prefab_name))
            throw new NullReferenceException("prefab_name need to initialize in derrived class");

        GameObject weapon = PoolManager.Instance.GetObjectFromPool(prefab_name);
        if (weapon == null)
            throw new InvalidOperationException("Weapon object could not be retrieved from the pool.");

        weapon.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;

        CustomizeShoot(weapon, direction);

        return damage;
    }

    protected virtual void CustomizeShoot(GameObject weapon, float direction)
    {
        ShootingMethods.Instance().ShootBasic(weapon,direction,xSpeed,destroyTime);
    }

}
