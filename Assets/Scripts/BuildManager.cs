using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        instance = this;
    }

    public GameObject standartTurretPreafab;
    
    private GameObject turretToBuild;

    private void Start()
    {
        turretToBuild = standartTurretPreafab;
    }

    public GameObject GetTurretToBuild()
    {
        return turretToBuild;
    }
}
