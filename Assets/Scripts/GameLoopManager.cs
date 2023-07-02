using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    public GameObject gameOverUI;

    public static bool gameEnded;

    private void Start()
    {
        gameEnded = false;
    }

    private void Update()
    {
        if (gameEnded) return;
        if (PlayerStats.Lives <= 0)
        {
            EndGame();
        }
    }

    private void EndGame()
    {
        gameEnded = true;
        gameOverUI.SetActive(true);
    }
}
