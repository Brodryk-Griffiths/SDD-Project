using UnityEngine;

public class Shop : MonoBehaviour
{
    public TurretBlueprint standardTurret;
    public TurretBlueprint laserTurret;
    BuildManager buildManager;
    
    void Start ()
    {
        buildManager = BuildManager.instance;
    }
    //selects which turret user wishes to build when they click on the appropriate turret icon in the shop
    public void SelectStandardTurret ()
    {
        Debug.Log ("Standard Turret Purchased");
        buildManager.SelectTurretToBuild(standardTurret);
    }
    public void SelectLaserTurret ()
    {
        Debug.Log ("Another Turret Purchased");
        buildManager.SelectTurretToBuild(laserTurret);
    }
}
