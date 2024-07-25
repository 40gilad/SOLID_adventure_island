using System;

public class Concrete_ColFruit : ConcreteCollectible
{
    public int effect;
    private int fruit_counter = 0;
    public static event Action FruitsBonus;

    public override void OnCollect()
    {
        try
        {
            UiElement.OnCollect(effect);
        }
        catch (NullReferenceException)
        {
            Init();
            UiElement.OnCollect(effect);

        }

        Destroy(gameObject);
        IncFruitCounter();
    }

    private void IncFruitCounter()
    {//inc and check bouns
        fruit_counter++;
        if (fruit_counter == 30)
        {
            fruit_counter = 0;
            FruitsBonus?.Invoke();
        }
    }
}
