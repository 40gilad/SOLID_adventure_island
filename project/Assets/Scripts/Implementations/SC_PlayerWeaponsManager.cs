using UnityEngine;

public class SC_PlayerWeaponsManager : MonoBehaviour
{
    public ConcreteWeaponController boomerang_weapon;
    public ConcreteWeaponController hammer_weapon;
    private ConcreteWeaponController curr;
    private string friendAnimal_color;



    private void OnEnable()
    {
        Cards_FriendsAnimalsManaeger.FriendAnimalOnCollect += OnFriendAnimalCollect;
    }

    private void OnDisable()
    {
        Cards_FriendsAnimalsManaeger.FriendAnimalOnCollect -= OnFriendAnimalCollect;
    }
    void Update()
    {
        curr = null;

        if (Input.GetKeyDown(KeyCode.B))
        {
            curr = boomerang_weapon;
        }
        else if (Input.GetKeyDown(KeyCode.H))
        {
            curr = hammer_weapon;
        }

        else if (Input.GetKeyDown(KeyCode.G)
            && !string.IsNullOrEmpty(friendAnimal_color))
        {
            transform.Find("Prefab_" + friendAnimal_color + "Dino(Clone)")
                .GetComponent<FriendAnimal>().Attack();
        }

        if (curr != null)
        {

            float direction = GameObject.FindGameObjectWithTag("Player").transform.localScale.x;
            curr.Shoot(direction);
        }
    }

    private void OnFriendAnimalCollect(string color=null)
    {
        if (!string.IsNullOrEmpty(color))
        {
            if (!string.IsNullOrEmpty(friendAnimal_color))
            {// colected friendAnimal while other friendAnimal is active
                Debug.Log("Impelement switch animals");
            }
            else
            {
                friendAnimal_color = color;
            }

        }
        else //animal turned off
            friendAnimal_color = null;

    }

    public void SetFriendAnimalColor(string color)
    {
        friendAnimal_color = color;
    }
}
