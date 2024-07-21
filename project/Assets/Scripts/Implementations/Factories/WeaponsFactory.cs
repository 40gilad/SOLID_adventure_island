using System;
using UnityEngine;

public class WeaponsFactory : Factory
{
    public override ConcreteCollectible CreateCollectible(string type)
    {
        base.CreateCollectible(null); //make sure that factory was initialize
        GameObject prefab = null;

        switch (type)
        {
            case "Boomerang":
                prefab = _prefabManager.ColBoomerangPrefab;
                break;
            default:
                throw new ArgumentException(type);
        }

        if (prefab == null)
            throw new ArgumentException("Prefab not found");

        return GameObject.Instantiate(prefab).GetComponent<Concrete_ColWeapon>();
    }
}