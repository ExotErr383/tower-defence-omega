using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public static int Money;
    public int startMoney = 1000;

    private void Start()
    {
        Money = startMoney;
    }
}
