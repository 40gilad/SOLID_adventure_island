using UnityEngine;

public abstract class FriendAnimal : MonoBehaviour
{
    public float destroyTime = 5.0f;
    public Color color;
    protected bool isCollected = false;
    protected GameObject player;

    void Awake()
    {
        Invoke("DestroySelf", destroyTime);
    }

    void DestroySelf()
    {
        PoolManager.Instance.ReturnObjectToPool(this.gameObject);
    }

    public void Collect(GameObject player)
    {
        if (CanBeCollected())
        {
            this.player = player;
            isCollected = true;
            CombineWithPlayer();
        }
    }

    protected abstract bool CanBeCollected();
    protected abstract void Attack();
    protected abstract void CombineWithPlayer();
}
