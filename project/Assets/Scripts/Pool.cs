using System.Collections.Generic;
using UnityEngine;

public class Pool
{
    private GameObject prefab;
    private Queue<GameObject> objects;

    public Pool(GameObject prefab, int initialSize)
    {
        this.prefab = prefab;
        objects = new Queue<GameObject>();
        GameObject parent = new GameObject("Pool_" + prefab.name);
        for (int i = 0; i < initialSize; i++)
        {
            GameObject newObj = GameObject.Instantiate(prefab);
            newObj.SetActive(false);
            newObj.transform.SetParent(parent.transform);
            objects.Enqueue(newObj);
        }
    }

    public GameObject GetObject()
    {
        if (objects.Count > 0)
        {
            GameObject obj = objects.Dequeue();
            obj.SetActive(true);
            return obj;
        }
        else
        {
            GameObject newObj = GameObject.Instantiate(prefab);
            newObj.SetActive(true);
            return newObj;
        }
    }

    public void ReturnObject(GameObject obj)
    {
        obj.SetActive(false);
        objects.Enqueue(obj);
    }
}
