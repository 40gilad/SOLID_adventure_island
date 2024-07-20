using System;
using System.Collections;
using TMPro;
using UnityEngine;

public class SC_PlayerPowerController : MonoBehaviour
{
    public SC_PlayerPowerModel model;
    public SC_PlayerPowerView view;
    public int initial_power;
    public int power_decrement_interval;

    void Start()
    {
        Init();
    }

    private void Init()
    {
        model = new SC_PlayerPowerModel(initial_power);
        view = new SC_PlayerPowerView(GetComponent<TextMeshProUGUI>());
        view.Update(model.Get());

        if (power_decrement_interval < 1)
            throw new ArgumentOutOfRangeException("power_decrement_interval");
        StartCoroutine(DecreaseLivesRoutine());
    }
    private IEnumerator DecreaseLivesRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(power_decrement_interval);
            model.Dec();
            view.Update(model.Get());
        }
    }


    /*
    public void OnLifeLost()
    {
        try
        {
            model.DecreaseLives();
            view.UpdateLivesDisplay(model.GetLives());
        }
        catch (InvalidOperationException e)
        {
            Debug.LogError(e.Message);
        }
    }

    public void OnLifeGained()
    {
        model.IncreaseLives();
        view.UpdateLivesDisplay(model.GetLives());
    }
    */
}


