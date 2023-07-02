using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public static int Lives;
    public static int Waves;
    
    public int startMoney = 1000;
    public int startLives = 30;

    private void Start()
    {
        Waves = 0;
        Money = startMoney;
        Lives = startLives;
    }
}
