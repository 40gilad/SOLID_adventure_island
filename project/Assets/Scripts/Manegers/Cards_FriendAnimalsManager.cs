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
            {"Fairy" ,"Prefab_Fairy"}
        };
        player = GameObject.FindGameObjectWithTag("Player");
        player_weapon_manager = player.GetComponent<SC_PlayerWeaponsManager>();

    }


    public void SetAnimal(string color)
    {
        if (color == "Fairy")
            Debug.Log("aa");
        string prefab_name = GetPrefabName(color);
        if (prefab_name == null)
            throw new ArgumentException(color);
        SwitchAnimals();
        curr_active_animal = PoolManager.Instance.GetObjectFromPool(prefab_name);
        curr_active_animal.transform.SetParent(player.transform, false);
        if (color == "Fairy")
            curr_active_animal.transform.localPosition = new Vector3(-1.5f, 1f, 0f);
        else
            curr_active_animal.transform.localPosition = new Vector3(0.2f, -0.5f,1f);
        curr_active_animal.GetComponent<FriendAnimal>().CombineWithPlayer();
        player_weapon_manager.SetFriendAnimalColor(color);

    }

    private void SwitchAnimals()
    {
        if (curr_active_animal == null)
            return;
        curr_active_animal.GetComponent<FriendAnimal>().GoToSleep();
        curr_active_animal = null;
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