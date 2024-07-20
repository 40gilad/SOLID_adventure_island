using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_PlayerLivesController : ConcreteUIElementController
{
    protected override void Init()
    {
        model = new SC_PlayerLivesModel(initial_amout);
        view = new SC_PlayerLivesView(GetComponent<TextMeshProUGUI>());
        view.UIUpdate(model.Get());
    }
}
