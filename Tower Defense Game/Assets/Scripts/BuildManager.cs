using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    void Awake ()
    {
        instance = this;
    }

    public GameObject standardTurretPrefab;
    public GameObject anotherTuretPrefab;

    private TurretBlueprint turretToBuild;
    //Enures that a turret can be built on selected node
    public bool CanBuild { get { return turretToBuild != null; } }

    public void BuildTurretOn (Node node)
    {
        if (PlayerStats.Money < turretToBuild.cost)
            {
                Debug.Log ("no moneys to build");
                return;
            }
            
            PlayerStats.Money -= turretToBuild.cost;
            GameObject turret = (GameObject)Instantiate(turretToBuild.prefab, node.GetBuildPosition(), Quaternion.identity);
            node.turret = turret;
            Debug.Log ("Turret has been Built! Remaiing money: " + PlayerStats.Money);
            
    }

     public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
    }
}
