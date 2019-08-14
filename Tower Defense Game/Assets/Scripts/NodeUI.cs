using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NodeUI : MonoBehaviour
{
    private Node target;
    public GameObject ui;
    public Text upgradeCost;
    public Text sellValue;
    public Button upgradeButton;
    public AudioClip sellSound;
    public void SetTarget(Node _target)
    {
        target = _target;
        //finds location of selected node
        transform.position = target.GetBuildPosition();
        //decides what the sell and upgrade cost will be/display depending on if the turret is upgraded.
        if (!target.isUpgraded)
        {
            upgradeCost.text = "-$" + target.turretBlueprint.upgradeCost;
            upgradeButton.interactable = true;
            sellValue.text = "+$" + target.turretBlueprint.GetSellAmount();
        }
        else
        {
            upgradeCost.text = "DONE!";
            upgradeButton.interactable = false;
            sellValue.text = "+$" + target.turretBlueprint.GetUpSellAmount();
        }
        //call function to enables floating menu where you can upgrade or sell selected turret
        ui.SetActive(true);
    }
    //caleed to hide floating ui
    public void Hide()
    {
        ui.SetActive(false);
    }
    //called from floating ui buttons to upgrade
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    //called from floating ui buttons to sell
    public void Sell ()
    {
        TurretSellAudio.sellEffect(sellSound);
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
