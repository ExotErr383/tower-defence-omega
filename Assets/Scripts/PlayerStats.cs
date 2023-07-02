using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public int startMoney = 1000;
    public int startLives = 30;
    private void Start()
    {
        Money = startMoney;
        Lives = startLives;
    }
}
