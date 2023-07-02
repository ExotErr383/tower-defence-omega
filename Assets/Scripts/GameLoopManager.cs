using UnityEngine;

public class GameLoopManager : MonoBehaviour
{
    private bool gameEnded = false;
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
        Debug.Log("Game Ended");
    }
}
