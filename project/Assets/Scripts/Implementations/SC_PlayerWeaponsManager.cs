using System;
using System.Collections.Generic;
using UnityEngine;

public class SC_PlayerWeaponsManager : MonoBehaviour
{
    public ConcreteWeaponController boomerang_weapon;
    public ConcreteWeaponController hammer_weapon;
    private ConcreteWeaponController curr;
    private string friendAnimal_color;
    public bool is_animal_attacking;
    private List<string> sprtie_changers_animals = new List<string> { "Blue", "Green","Red","Fairy" };

    void Update()
    {
        curr = null;

        if (Input.GetKeyDown(KeyCode.X))
        {
            curr = boomerang_weapon;
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            curr = hammer_weapon;
        }

        else if (Input.GetKeyDown(KeyCode.C)
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

    public bool IsAnimalAttacking()
    {
        return (is_animal_attacking &&
            sprtie_changers_animals.Contains(friendAnimal_color));
    }

    public string GetColor()
    {
        return friendAnimal_color;
    }
}
