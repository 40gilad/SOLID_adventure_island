using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class SC_PlayerPowerView : ConcreteUIElementView
{
    public SC_PlayerPowerView(TextMeshProUGUI txt) : base(txt) { }

    public override void UIUpdate(int amount)
    {
        string _power = string.Empty;
        for (int i = 0; i < amount; i++)
            _power += "I";
        text_element.text = _power;
    }
}
