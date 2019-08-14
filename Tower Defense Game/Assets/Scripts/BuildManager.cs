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
        //for deselecting selected node by clicking it again
        if (selectedNode == node)
        {
            DeselectNode();
            return;
        }
        //sets this node as the selected node
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
    //selects the turret to be built... called from shop buttons
    public void SelectTurretToBuild(TurretBlueprint turret)
    {
        turretToBuild = turret;
        //Ensures a node cannot be selected at the same time as a turret to build
        DeselectNode();
        AudioManager.buttonSound();
    }
}
