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
    public NodeUI nodeUI;

    public TurretBlueprint turretToBuild;
    private Node selectedNode;
    //Enures that a turret can be built on selected node
    public bool CanBuild { get { return turretToBuild != null; } }

    public void SelectNode (Node node)
    {
        
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.SetTarget(node);
        AudioManager.buttonSound();
    }
    public void DeselectNode()
    {
        nodeUI.Hide();
        selectedNode = null;
    }
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        
        turretToBuild = turret;
        DeselectNode();
        //AudioManager.buttonSound();
    }
}
