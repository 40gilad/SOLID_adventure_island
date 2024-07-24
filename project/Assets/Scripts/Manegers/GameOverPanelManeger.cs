using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverPanelManeger : MonoBehaviour
{
    public GameObject gameOverTextObject;
    TextMeshProUGUI gameOverText;
    // Start is called before the first frame update
    void Start()
    {
        gameOverText = gameOverTextObject.GetComponent<TextMeshProUGUI>();
        ShowGameOver();
    }

    public void ShowGameOver()
    {
        StartCoroutine(GameOverCountdown());
    }

    private IEnumerator GameOverCountdown()
    {
        int countdown = 3;
        while (countdown > 0)
        {
            gameOverText.text = $"Game Over\nWill Start Again in {countdown}";
            yield return new WaitForSeconds(1);
            countdown--;
        }
        gameOverText.text = "Game Over\nWill Start Again in 0";
        yield return new WaitForSeconds(1);
        // Restart the scene
        UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
    }
}
