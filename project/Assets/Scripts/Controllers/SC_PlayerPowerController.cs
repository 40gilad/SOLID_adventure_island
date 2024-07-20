using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SC_PlayerPowerController : ConcreteUIElementController
{
    public int power_decrement_interval;

    protected override void Init()
    {
        model = new SC_PlayerPowerModel(initial_amout);
        view = new SC_PlayerPowerView(GetComponent<TextMeshProUGUI>());
        view.UIUpdate(model.Get());

        if (power_decrement_interval < 1)
            throw new ArgumentOutOfRangeException("power_decrement_interval");
        StartCoroutine(DecreaseLivesRoutine());
    }
    private IEnumerator DecreaseLivesRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(power_decrement_interval);
            model.Get();
            model.Dec();
            view.UIUpdate(model.Get());
        }
    }
}


