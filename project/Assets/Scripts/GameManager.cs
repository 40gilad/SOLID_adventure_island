using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PrefabManager prefabManager;
    private Dictionary<string, Factory> factories;

    void Start()
    {
        Init();
        ConcreteCollectible pineapple = factories["Fruits"].CreateCollectible("Pineapple");
        pineapple.transform.position = new Vector3(0, 1.5f, 0);
        ConcreteCollectible grape = factories["Fruits"].CreateCollectible("Grape");
        grape.transform.position = new Vector3(15, 1.5f, 0);
        ConcreteCollectible boomerang = factories["Weapons"].CreateCollectible("Boomerang");
        boomerang.transform.position = new Vector3(10, 1.5f, 0);

    }

    private void Init()
    {
        InitFactoriesDict();
        InitFactories();
    }

    private void InitFactoriesDict()
    {

        factories = new Dictionary<string, Factory>()
        {
            { "Fruits",new FruitsFactory() },
            { "Weapons",new WeaponsFactory() }
        };
    }

    private void InitFactories()
    {
        foreach (KeyValuePair<string, Factory> kvp in factories)
            kvp.Value.Initialize(prefabManager);
    }
}
