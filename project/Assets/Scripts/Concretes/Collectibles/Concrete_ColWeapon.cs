using System;
using UnityEngine;

public class Concrete_ColWeapon : ConcreteCollectible
{

    public override void OnCollect()
    {
        PoolManager.Instance.ReturnObjectToPool(this.gameObject);
        try
        {
            UiElement.OnCollect();
        }
        catch (NullReferenceException)
        {
            Init();
            UiElement.OnCollect();

        }


    }
}
