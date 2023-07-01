using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject standartTurretPreafab;
    public GameObject missileTurretPreafab;

    private TurretBlueprint turretToBuild;
    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }

    public void BuildTurretOn(TurretPlatform platform)
    {
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not enough money!");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;
        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, platform.GetBuildPosition(), Quaternion.identity);
        platform.turret = turret;
        Debug.Log($"Turret build. Money left: {PlayerStats.Money}");
    }
}
