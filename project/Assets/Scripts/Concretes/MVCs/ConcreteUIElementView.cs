using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ConcreteUIElementView
{

    public TextMeshProUGUI text_element;

    public ConcreteUIElementView(TextMeshProUGUI txt)
    {
        text_element = txt;
    }
    public abstract void UIUpdate(int amount);
}
