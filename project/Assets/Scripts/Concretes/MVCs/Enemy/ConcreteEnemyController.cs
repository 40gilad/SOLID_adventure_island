using UnityEngine;

public abstract class ConcreteEnemyController: MonoBehaviour
{
    protected ConcreteEnemyModel model;
    public int damage;
    private static System.Random random = new System.Random();


    private void Awake()
    {
        Init();
    }

    public virtual void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
            model.PlayerCollider(other);
        else if (other.gameObject.tag.StartsWith("Weapon"))
            model.WeaponCollider(other);
        if (other.CompareTag("Wall"))
            model.WallCollider();

    }

    protected abstract void Init();

    public virtual void Died(bool is_wall=false)
    {
        if (!is_wall)
            LayEgg();
        gameObject.SetActive(false);
    }

    private void LayEgg()
    {
        bool to_lay_an_egg = FlipCoin();
        if (!to_lay_an_egg)
            return;
        GameObject egg =PoolManager.Instance.GetObjectFromPool("Prefab_Egg");
        egg.SetActive(true);
        egg.transform.position = new Vector3(this.transform.position.x, 0.9f, -1f);
    }

    public bool FlipCoin()
    {
        return (random.Next(0, 2) == 0);
    }

    public bool OutOfThree()
    {
        return (random.Next(0, 3) == 2);
    }


}
