using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject confirmationUI;
    public string gameLevelToLoad = "GameLevel";

    private void Start()
    {
        confirmationUI.SetActive(false);
    }
    public void Play()
    {
        SceneManager.LoadScene(gameLevelToLoad);
    }

    public void Quit()
    {
        confirmationUI.SetActive(true);
    }

    public void DoQuit()
    {
        Debug.Log("Exiting application");
        Application.Quit();
    }

    public void DontQuit()
    {
        confirmationUI.SetActive(false);
    }
}
