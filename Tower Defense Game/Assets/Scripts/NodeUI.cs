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

        transform.position = target.GetBuildPosition();
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
        
        
        
        ui.SetActive(true);
    }
    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeselectNode();
    }
    public void Sell ()
    {
        TurretSellAudio.sellEffect(sellSound);
        target.SellTurret();
        BuildManager.instance.DeselectNode();
    }
}
