using System;
using UnityEngine;

public class Concrete_ColWeapon : ConcreteCollectible
{

    public override void OnCollect()
    {
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
