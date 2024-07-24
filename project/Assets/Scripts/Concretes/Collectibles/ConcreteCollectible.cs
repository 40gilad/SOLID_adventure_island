using UnityEngine;

public abstract class ConcreteCollectible : MonoBehaviour, ICollectible
{
    public string UiElementName;
    protected ConcreteUIElementController UiElement;

    private void Start()
    {
        Init();
    }

    protected virtual void Init()
    {
        UiElement = GameObject.Find(UiElementName).GetComponent<ConcreteUIElementController>();
    }
    public abstract void OnCollect();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { // player collider touch 'my_collider'
            OnCollect();
        }
    }


}