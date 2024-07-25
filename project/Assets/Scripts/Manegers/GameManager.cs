using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PrefabManager prefabManager;
    private Dictionary<string, Factory> factories;
    public GameObject game_over_panel;


    void Start()
    {
        Init();
        ConcreteCollectible pineapple = factories["Fruits"].CreateCollectible("Pineapple");
        pineapple.transform.position = new Vector3(-3, 1.5f, 0);
        ConcreteCollectible grape = factories["Fruits"].CreateCollectible("Grape");
        grape.transform.position = new Vector3(15, 1.5f, 0);

    }
    private void OnEnable()
    {
        SC_PlayerController.GameOver += GameOver;
    }

    private void OnDisable()
    {
        SC_PlayerController.GameOver -= GameOver;

    }

    private void Init()
    {
        InitFactoriesDict();
        InitFactories();
        InitPositions();

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

    private void InitPositions()
    {

    }
    public void GameOver()
    {
        StartCoroutine(ShowGameOverScreen());
    }

    private IEnumerator ShowGameOverScreen()
    {
        game_over_panel.SetActive(true);
        yield return new WaitForSeconds(3);
        game_over_panel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
