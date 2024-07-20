using UnityEngine;

public class Concrete_ColFruit : ConcreteCollectible
{
    public int effect;


    public override void OnCollect()
    {
        Debug.Log(name + " Fruit Collected with Power: " + effect);
        UiElement.OnCollect(effect);

    }
}
