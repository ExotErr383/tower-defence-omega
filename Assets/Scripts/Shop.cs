using UnityEngine;

public class Shop : MonoBehaviour
{
    BuildManager buildManager;
    public TurretBlueprint standartTurret;
    public TurretBlueprint missileTurret;

    private void Start()
    {
        buildManager = BuildManager.instance;
    }

    public void SelectStandartTurret()
    {
        Debug.Log("Selected Standart Turret");
        buildManager.SelectTurretToBuild(standartTurret);
    }

    public void SelectMissileTurret()
    {
        Debug.Log("Selected Missile Turret");
        buildManager.SelectTurretToBuild(missileTurret);
    }
}
