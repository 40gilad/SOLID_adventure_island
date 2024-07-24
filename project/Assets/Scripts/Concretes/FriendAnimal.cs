using UnityEngine;

public abstract class FriendAnimal : MonoBehaviour
{
    public float destroyTime = 5.0f;
    protected bool isCollected = false;
    protected SC_PlayerWeaponsManager player_weapon_manager;

    void Awake()
    {
        Invoke("DestroySelf", destroyTime);
        player_weapon_manager = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<SC_PlayerWeaponsManager>();

    }

    void DestroySelf()
    {
        PoolManager.Instance.ReturnObjectToPool(this.gameObject);
        player_weapon_manager.SetFriendAnimalColor(string.Empty);
    }


    protected abstract bool CanBeCollected();
    public abstract void Attack();
    protected abstract void CombineWithPlayer();
}
