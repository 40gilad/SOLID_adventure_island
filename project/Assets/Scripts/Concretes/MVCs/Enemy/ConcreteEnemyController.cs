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
        if (other.gameObject.tag == "Player") // check if has fairy or animal. if animal, bonefire. fairy- everthing
            model.PlayerCollider();
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
        GameObject egg =PoolManager.Instance.GetObjectFromPool("Prefab_Egg");
        egg.SetActive(true);
        egg.transform.position = new Vector3(this.transform.position.x, 0.9f, -1f);
    }


}
