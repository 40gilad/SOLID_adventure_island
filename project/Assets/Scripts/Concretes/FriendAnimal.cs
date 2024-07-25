using UnityEngine;

public abstract class FriendAnimal : MonoBehaviour
{
    public float destroyTime = 5.0f;
    protected bool isCollected = false;
    protected SC_PlayerWeaponsManager player_weapon_manager;



    public Sprite attackSprite;
    private SpriteRenderer spriteRenderer;
    private Sprite originalSprite;

    void Awake()
    {
        player_weapon_manager = GameObject.FindGameObjectWithTag("Player")
            .GetComponent<SC_PlayerWeaponsManager>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        originalSprite = spriteRenderer.sprite;
    }

    void DestroySelf()
    {
        PoolManager.Instance.ReturnObjectToPool(this.gameObject);
        player_weapon_manager.SetFriendAnimalColor(string.Empty);
    }

    public void GoToSleep()
     {
        DestroySelf();
    }

    protected virtual void PlayerCollider(Collider2D other)
    {
        if (other.tag.StartsWith("Enemy"))
        {
            if (other.gameObject.name.StartsWith("Prefab_BonfireEnemy"))
                DestroySelf();
        }

    }

    protected void ChangeSprite()
    {
        if (spriteRenderer != null && attackSprite != null)
        {
            spriteRenderer.sprite = attackSprite;
        }
    }

    protected void RevertSprite()
    {
        if (spriteRenderer != null)
        {
            spriteRenderer.sprite = originalSprite;
        }
    }

    public abstract void Attack();
    public void CombineWithPlayer()
    {
        Invoke("DestroySelf", destroyTime);
    }
}
