using System;
using System.Threading.Tasks;
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

    public  async void Shoot(float direction)
    {
        int damage = await model.ShootAsync(direction);
        UiElement.Dec(damage);
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
