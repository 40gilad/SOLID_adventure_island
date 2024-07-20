using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SC_PlayerPowerView
{
    public TextMeshProUGUI powerUI;

    public SC_PlayerPowerView(TextMeshProUGUI txt)
    {
        powerUI = txt;
    }

    public void Update(int power)
    {
        string _power = string.Empty;
        for (int i = 0; i < power; i++)
            _power += "I";
        powerUI.text = _power;
    }
}
