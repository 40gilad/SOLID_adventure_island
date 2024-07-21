using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class ConcreteUIElementController : MonoBehaviour
{
    public ConcreteUIElementModel model;
    public ConcreteUIElementView view;
    public int initial_amout;

    void Awake()
    {

        Init();
    }

    protected abstract void Init();

    public void OnCollect(int effect = 1)
    {
        model.Inc(effect);
        view.UIUpdate(model.Get());
    }

}
