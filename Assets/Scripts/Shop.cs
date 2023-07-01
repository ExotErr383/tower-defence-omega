using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void PurchaseStandartTurret()
    {
        Debug.Log("Selected Standart Turret");
        buildManager.SetTurretToBuild(buildManager.standartTurretPreafab);
    }

    public void PurchaseAnotherTurret()
    {
        Debug.Log("Selected Another Turret");
        buildManager.SetTurretToBuild(buildManager.anotherTurretPreafab);
    }
}
