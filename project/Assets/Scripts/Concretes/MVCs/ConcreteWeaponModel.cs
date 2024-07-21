using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public abstract class ConcreteWeaponModel
{
    public int damage;
    public string prefab_name;
    public virtual int Shoot()
    {
        if (prefab_name == null)
            throw new NullReferenceException("prefab_name need to initialize in derrived class");
        GameObject wep = PoolManager.Instance.GetObjectFromPool(prefab_name);
        wep.transform.position = new Vector3(1, 2, 0);
        Debug.Log(prefab_name+ " Shoot");
        return damage;
    }

}
