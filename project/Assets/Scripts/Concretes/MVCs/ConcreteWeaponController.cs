using System;
using UnityEngine;

public abstract class ConcreteWeaponController : MonoBehaviour
{
    public ConcreteWeaponModel model;
    public ConcreteUIElementView view;
    public string UiElementName;
    protected ConcreteUIElementModel UiElement;

    public int damage = 1;
    public float xSpeed = 100f;
    public float ySpeed = 5f;
    public float destroyTime = 5f;

    void Start()
    {
        Init();
    }

    public void Shoot(float direction)
    {
        int effect = model.Shoot(direction);
        UiElement.Dec(effect);
        view.UIUpdate(UiElement.Get());
    }

    protected virtual void Init()
    {
        ConcreteUIElementController uiElementController = GameObject.Find(UiElementName).GetComponent<ConcreteUIElementController>();
        if (uiElementController != null)
        {
            UiElement = uiElementController.model;
            view = uiElementController.view;
        }
        else
            throw new NullReferenceException("UIElementController");

        model.damage = damage;
        model.xSpeed = xSpeed;
        model.ySpeed = ySpeed;
        model.destroyTime = destroyTime;
    }
}
