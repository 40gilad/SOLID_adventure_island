using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public PrefabManager prefabManager;
    private Dictionary<string, Factory> factories;
    public GameObject game_over_panel;
    private List<string> levels;



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
        SC_PlayerController.PlayerCaveCollision += FinishedLevel;
    }

    private void OnDisable()
    {
        SC_PlayerController.GameOver -= GameOver;
        SC_PlayerController.PlayerCaveCollision -= FinishedLevel;

    }

    private void Init()
    {
        InitFactoriesDict();
        InitFactories();
        InitPositions();
        InitLevels();

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
        Debug.Log("Init fruits and enemies positions");
    }

    private void InitLevels()
    {
        levels = new List<string> {
            "FirstLevel",
            "SecondLevel"
        };
    }
    public void GameOver()
    {
        StartCoroutine(ShowGameOverScreen());
    }

    private void FinishedLevel()
    {
        Debug.Log("Finished Level");
        LoadNextLevel();

    }

    private void LoadNextLevel()
    {
        int scene_to_load_index = levels.IndexOf(SceneManager.GetActiveScene().name);
        ++scene_to_load_index;

        if (scene_to_load_index < levels.Count)
        {
            SceneManager.LoadScene(levels[scene_to_load_index]);
        }
        else
        {
            Debug.Log("All levels finished! Restarting...");
            SceneManager.LoadScene(levels[0]);
        }
    }

    private IEnumerator ShowGameOverScreen()
    {
        game_over_panel.SetActive(true);
        yield return new WaitForSeconds(3);
        game_over_panel.SetActive(false);
        SceneManager.LoadScene(levels[0]);
    }
}
