using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_PlayerHammerView : ConcreteUIElementView
{
    public SC_PlayerHammerView(TextMeshProUGUI txt) : base(txt) { }

    public override void UIUpdate(int amount)
    {
        text_element.text = amount.ToString();
    }
}
