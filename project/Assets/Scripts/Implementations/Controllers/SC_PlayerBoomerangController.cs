using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SC_PlayerBoomerangController : ConcreteUIElementController
{
    protected override void Init()
    {
        model = new SC_PlayerBoomerangModel(this, initial_amout);
        view = new SC_PlayerBoomerangView(GetComponent<TextMeshProUGUI>());
        view.UIUpdate(model.Get());
    }

}
