using System;
using System.Collections.Generic;
using UnityEngine;

public class Cards_FriendsAnimalsManaeger : MonoBehaviour
{
    private Dictionary<string, string> color_prefab_name_dict;
    private void Init()
    {
        color_prefab_name_dict = new Dictionary<string, string>()
        {
            {"Red", "Prefab_RedDino"},
            {"Blue", "Prefab_BlueDino"},
            {"Green", "Prefab_GreenDino"}
        };
    }


    public void SetAnimal(string color)
    {
        string prefab_name = GetPrefabName(color);
        if (prefab_name == null)
            throw new ArgumentException(color);
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        GameObject curr = PoolManager.Instance.GetObjectFromPool(prefab_name);
        curr.transform.SetParent(player.transform, false);
        curr.transform.localPosition = new Vector3(0.2f, -0.7f,1f);

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