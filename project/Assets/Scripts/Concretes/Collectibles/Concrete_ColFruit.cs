using System;
using UnityEngine;

public class Concrete_ColFruit : ConcreteCollectible
{
    public int effect;

    public override void OnCollect()
    {
        try
        {
            UiElement.OnCollect(effect);
        }
        catch (NullReferenceException ex)
        {
            Init();
            UiElement.OnCollect(effect);

        }

        
    }
}
