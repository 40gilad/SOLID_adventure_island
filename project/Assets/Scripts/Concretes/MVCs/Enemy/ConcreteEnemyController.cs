using UnityEngine;

public abstract class ConcreteEnemyController: MonoBehaviour
{
    protected ConcreteEnemyModel model;
    public int damage;

    private void Awake()
    {
        Init();
    }
    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            model.PlayerCollider();
        else if (other.gameObject.tag.StartsWith("Weapon"))
            model.WeaponCollider(other);
    }
    protected abstract void Init();

    public void Died()
    {
        gameObject.SetActive(false);
    }
}
