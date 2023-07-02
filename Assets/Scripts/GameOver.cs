using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public TextMeshProUGUI wavesText;
    public string mainMenuScene = "MainMenu";

    private void OnEnable()
    {
        wavesText.text = PlayerStats.Waves.ToString();
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(mainMenuScene);
    }
}
