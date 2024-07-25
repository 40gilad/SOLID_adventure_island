using System.Collections.Generic;

public class PrefabList
{
    private static PrefabList _instance;
    private List<string> prefab_list;
    private PrefabList()
    {
        prefab_list = new List<string> {
            "Col_Boomerang",
            "Col_Hammer",
            "Prefab_HeartCard",
            "Prefab_LeafCard",
            "Prefab_StarCard",
            "Prefab_Fairy"
        };
    }

    public static PrefabList Instance()
    {
        if (_instance == null)
            _instance = new PrefabList();
        return _instance;
    }

    public int Amount()
    {
        return prefab_list.Count;
    }

    public List<string> Get()
    {
        return prefab_list;
    }

    public string Get(int indx)
    {
        return prefab_list[indx].ToString();
    }

}