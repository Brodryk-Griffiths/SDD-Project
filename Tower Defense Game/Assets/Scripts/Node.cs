using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Vector3 positionOffset;

    public GameObject turret;
    public TurretBlueprint turretBlueprint;
    private Renderer rend;
    private Color startColor;
    public bool isUpgraded = false;
    BuildManager buildManager;

    void Start ()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;

        buildManager = BuildManager.instance;
    }
    public Vector3 GetBuildPosition ()
    {
        return transform.position + positionOffset;
    }

    void OnMouseDown ()
    {
        
        if (turret != null)
        {
            buildManager.SelectNode(this);
            return;
        }
        if (!buildManager.CanBuild)
        {
            return;
        }
        //Build a turret
        BuildTurret (buildManager.turretToBuild);
    }

    void BuildTurret (TurretBlueprint blueprint)
    {
        if (PlayerStats.Money < blueprint.cost)
            {
                Debug.Log ("no moneys to ");
                buildManager.turretToBuild = null;
                return;
            }
            
            PlayerStats.Money -= blueprint.cost;
            GameObject _turret = (GameObject)Instantiate(blueprint.prefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            turretBlueprint = blueprint;
            Debug.Log ("Turret has been Built! Remaiing money: " + PlayerStats.Money);
            buildManager.turretToBuild = null;
            
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBlueprint.upgradeCost)
            {
                Debug.Log ("no moneys to build");
                return;
            }
            Destroy(turret);//Get rid of old turret

            // Build new one
            PlayerStats.Money -= turretBlueprint.upgradeCost;
            GameObject _turret = (GameObject)Instantiate(turretBlueprint.upgradedPrefab, GetBuildPosition(), Quaternion.identity);
            turret = _turret;
            isUpgraded = true;
            Debug.Log ("Turret has been upgraded!");
    }

    public void SellTurret()
    {
        if (isUpgraded == false)
        {
            PlayerStats.Money += turretBlueprint.GetSellAmount();
        }
        else if (isUpgraded == true)
        {
            PlayerStats.Money += turretBlueprint.GetUpSellAmount();
        }

        Destroy(turret);
        turretBlueprint = null;
        turret = null;
        isUpgraded = false;
    }
    void OnMouseEnter ()
    {
        if (turret != null)
        {
            rend.material.color = hoverColor;
        }
        if (!buildManager.CanBuild)
            return;
        rend.material.color = hoverColor;
    }
    void OnMouseExit ()
    {
        rend.material.color = startColor;
    }
}