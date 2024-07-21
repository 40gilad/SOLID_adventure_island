using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_PlayerHammerController : ConcreteUIElementController
{
    protected override void Init()
    {
        model = new SC_PlayerHammerModel(initial_amout);
        view = new SC_PlayerHammerView(GetComponent<TextMeshProUGUI>());
        view.UIUpdate(model.Get());
    }
}
