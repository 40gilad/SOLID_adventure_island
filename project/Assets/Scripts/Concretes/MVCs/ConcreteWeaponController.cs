using System;
using UnityEngine;

public abstract class ConcreteWeaponController : MonoBehaviour
{
    public ConcreteWeaponModel model;
    public ConcreteUIElementView view;


    public string UiElementName;
    protected ConcreteUIElementModel UiElement;

    void Start()
    {
        Init();
    }
    
    public void Shoot(int effect=1)
    {
        model.Shoot(effect);
        UiElement.Dec(effect);
        view.UIUpdate(UiElement.Get());

    }

    protected virtual void Init()
    {
        UiElement = GameObject.Find(UiElementName).GetComponent<ConcreteUIElementController>().model;
        view = GameObject.Find(UiElementName).GetComponent<ConcreteUIElementController>().view;

    }

}