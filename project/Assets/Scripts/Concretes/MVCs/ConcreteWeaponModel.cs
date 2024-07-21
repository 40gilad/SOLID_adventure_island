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
        if (prefab_name == null)
            throw new NullReferenceException("prefab_name need to initialize in derrived class");
        GameObject wep = PoolManager.Instance.GetObjectFromPool(prefab_name);

        wep.transform.position = new Vector3(direction, 2, 0);
        wep.GetComponent<Rigidbody2D>().AddForce(new Vector3(xSpeed * direction, ySpeed, 0));
        Debug.Log(prefab_name+ " Shoot");

        //StartCoroutine(DestroyObject(wep));
        return damage;
    }

}
