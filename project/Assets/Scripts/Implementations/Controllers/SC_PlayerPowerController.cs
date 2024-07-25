using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SC_PlayerPowerController : ConcreteUIElementController
{
    public static event Action OutOfPower;
    public int power_decrement_interval;

    protected override void Init()
    {
        model = new SC_PlayerPowerModel(this, initial_amout);
        view = new SC_PlayerPowerView(GetComponent<TextMeshProUGUI>());
        view.UIUpdate(model.Get());

        if (power_decrement_interval < 1)
            throw new ArgumentOutOfRangeException("power_decrement_interval");
        StartCoroutine(DecreaseLivesRoutine());
    }
    private IEnumerator DecreaseLivesRoutine()
    {
        int curr_amount;
        while (true)
        {
            yield return new WaitForSeconds(power_decrement_interval);
            model.Dec();
            curr_amount = model.Get();
            view.UIUpdate(curr_amount);
            if (curr_amount <= 0)
            {
                OutOfPower?.Invoke();
                DestroyModelAndView();
                Init();
                yield break;
            }
        }
    }

    private void DestroyModelAndView()
    {
        model = null;
        view = null;
    }
}


