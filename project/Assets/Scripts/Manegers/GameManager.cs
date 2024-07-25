using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject game_over_panel;
    private List<string> levels;
    public SC_ColAndEnemiesPositions sc_ColAndEnemiesPositions;


    void Start()
    {
        Init();

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
        InitPositions();
        InitLevels();
    }


    private void InitPositions()
    {
        sc_ColAndEnemiesPositions.PlaceObjects();
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
