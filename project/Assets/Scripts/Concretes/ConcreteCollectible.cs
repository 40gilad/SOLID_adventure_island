using UnityEngine;

public abstract class ConcreteCollectible : MonoBehaviour, ICollectible
{
    public ConcreteUIElementController UiElement;
    public abstract void OnCollect();

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        { // player collider touch 'my_collider'
            Destroy(gameObject);
            OnCollect();
        }
    }
}