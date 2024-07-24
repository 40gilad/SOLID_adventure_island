using System;
using UnityEngine;

public class SC_PlayerWeaponsManager : MonoBehaviour
{
    public ConcreteWeaponController boomerang_weapon;
    public ConcreteWeaponController hammer_weapon;
    private ConcreteWeaponController curr;
    private string friendAnimal_color;

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
            try
            {
                transform.Find("Prefab_" + friendAnimal_color + "Dino(Clone)")
                    .GetComponent<FriendAnimal>().Attack();
            }
            catch (NullReferenceException)
            {
                transform.Find("Prefab_" + friendAnimal_color + "(Clone)")
                    .GetComponent<FriendAnimal>().Attack();
            }
        }

        if (curr != null)
        {

            float direction = GameObject.FindGameObjectWithTag("Player").transform.localScale.x;
            curr.Shoot(direction);
        }
    }

    public void SetFriendAnimalColor(string color)
    {
        friendAnimal_color = color;
    }

    public string GetFriendAnimal()
    {
        return friendAnimal_color;
    }
}
