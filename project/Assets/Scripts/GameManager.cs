using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PrefabManager prefabManager;

    void Start()
    {
        FruitsFactory.Initialize(prefabManager);
        ConcreteCollectible pineapple = FruitsFactory.CreateCollectible("Pineapple");
        pineapple.transform.position = new Vector3(0, 2, 0);

    }
}
