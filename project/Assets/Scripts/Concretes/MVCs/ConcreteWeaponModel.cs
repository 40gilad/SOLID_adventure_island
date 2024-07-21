using System;
using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;

public abstract class ConcreteWeaponModel
{


    public virtual void Shoot(int effect = 1)
    {
        Debug.Log("Weapon Shoot");
    }

}
