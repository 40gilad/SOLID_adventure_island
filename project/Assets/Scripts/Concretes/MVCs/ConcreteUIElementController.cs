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

    void Start()
    {

        Init();
    }

    protected abstract void Init();

    public abstract void OnCollect(int effect);

}
