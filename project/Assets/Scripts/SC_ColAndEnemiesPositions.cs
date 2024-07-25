using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC_ColAndEnemiesPositions : MonoBehaviour
{
    private List<GameObject> groundObjects;
    private List<string> enemies_objects;
    private List<string> fruits_objects;
    public PrefabManager prefabManager;

    private Dictionary<string, Factory> factories;


    private void Start()
    {
        InitLists();
        InitFactories();
        GetAllGrounds();
    }
    public void PlaceObjects()
    {
        int objects_amount = 20;

        while (--objects_amount!=0)
        {
            if (!Lottery.Instance().TwoOutOfThree())// 2/3 to place an object
                continue;
            float x_pos = GetGroundX();
            ConcreteCollectible fruit = null;
            ConcreteEnemyController enemy = null;
            bool to_place_fruit = Lottery.Instance().TwoOutOfThree();
            if (to_place_fruit) // 2/3 for fruit object
            {
                fruit = GetFruit();
                fruit.transform.position = new Vector3(x_pos, 1.5f, 0);
            }
            else // 1/3 for enemy object
            {
                enemy = GetEnemy();
                enemy.transform.position = new Vector3(x_pos, 1.5f, 0);
            }

        }


    }
    private ConcreteEnemyController GetEnemy()
    {
        int indx = Lottery.Instance().JustRand(enemies_objects.Count);
        return factories["Enemies"].CreateEnemy(enemies_objects[indx]);
    }
    private ConcreteCollectible GetFruit()
    {
        int indx=Lottery.Instance().FlipCoin()==true ? 1 : 0;
        return factories["Fruits"].CreateCollectible(fruits_objects[indx]);
    }


    private void GetAllGrounds()
    {
        groundObjects = new List<GameObject>();
        GameObject[] grounds = GameObject.FindGameObjectsWithTag("Ground");
        groundObjects.AddRange(grounds);
    }

    private float GetGroundX()
    {
        int indx = Lottery.Instance().JustRand(groundObjects.Count);
        return groundObjects[indx].transform.position.x;
        //groundObjects.Remove(curr_ground);
    }

    private void InitLists()
    {
        fruits_objects = new List<string>()
        {
            "Pineapple",
            "Grape"
        };
        enemies_objects = new List<string>() {

            "Rock",
            "Bonfire",
            "Bird",
            "Snake",
            "Ghost",
            "Spider",
            "Frog"
        };
    }

    private void InitFactoriesDict()
    {

        factories = new Dictionary<string, Factory>()
        {
            { "Fruits",new FruitsFactory() },
            { "Weapons",new WeaponsFactory() },
            { "Enemies",new EnemiesFactory() }
        };
    }

    private void InitFactories()
    {
        InitFactoriesDict();
        foreach (KeyValuePair<string, Factory> kvp in factories)
            kvp.Value.Initialize(prefabManager);
    }
    /*
    ConcreteCollectible grape = factories["Fruits"].CreateCollectible("Grape");
    grape.transform.position = new Vector3(15, 1.5f, 0);
    ConcreteEnemyController spider = factories["Enemies"].CreateEnemy("Spider");
    spider.transform.position = new Vector3(15, 1.5f, 0);
    */
}
