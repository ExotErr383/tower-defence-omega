using UnityEngine;
using TMPro;
public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    void Update()
    {
        livesText.text = PlayerStats.Lives.ToString() + " HP";
    }
}
