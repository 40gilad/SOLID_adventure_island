using System.Collections.Generic;
using UnityEngine;

public class TagNames
{
    private static TagNames _instance;
    public static List<string> tags;

    public static TagNames Instance
    {
        get
        {
            if (_instance == null)
                Init();
            return _instance;
        }
    }

    private static void Init()
    {
        tags = new List<string> { "fruit", "wapon" };

    }

    public bool IsTag(string tag)
    {
        return tags.Contains(tag);
    }

}
   
