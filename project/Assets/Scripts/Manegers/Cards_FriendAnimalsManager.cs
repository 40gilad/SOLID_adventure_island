using System;
using System.Collections.Generic;
using UnityEngine;

public class Cards_FriendsAnimalsManaeger : MonoBehaviour
{
    private Dictionary<string, string> color_prefab_name_dict;
    private SC_PlayerWeaponsManager player_weapon_manager;
    GameObject player;
    GameObject curr_active_animal;


    private void Init()
    {
        color_prefab_name_dict = new Dictionary<string, string>()
        {
            {"Red", "Prefab_RedDino"},
            {"Blue", "Prefab_BlueDino"},
            {"Green", "Prefab_GreenDino"},
        };
        player = GameObject.FindGameObjectWithTag("Player");
        player_weapon_manager = player.GetComponent<SC_PlayerWeaponsManager>();

    }


    public void SetAnimal(string color)
    {
        string prefab_name = GetPrefabName(color);
        if (prefab_name == null)
            throw new ArgumentException(color);
        SwitchAnimals();

        curr_active_animal = PoolManager.Instance.GetObjectFromPool(prefab_name);
        curr_active_animal.transform.SetParent(player.transform, false);
        curr_active_animal.transform.localPosition = new Vector3(0.2f, -0.7f,1f);
        player_weapon_manager.SetFriendAnimalColor(color);


    }

    private void SwitchAnimals()
    {
        if (curr_active_animal == null)
            return;
        curr_active_animal.GetComponent<FriendAnimal>().GoToSleep();
    }

    public string GetPrefabName(string color)
    {
        if (color_prefab_name_dict == null)
            Init();
        if (color_prefab_name_dict.ContainsKey(color))
            return color_prefab_name_dict[color];
        return null;
    }
}