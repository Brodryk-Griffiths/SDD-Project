using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class TurretBlueprint 
{
    public GameObject prefab;
    public int cost;

    public GameObject upgradedPrefab;
    public int upgradeCost;
    //called fron nodeUI to return the amout of money to refund to the player, depending on whether the turret is upgraded or not
    public int GetSellAmount()
    {
        return cost / 2;
    }
    public int GetUpSellAmount()
    {
        return (cost + upgradeCost)/2;
    }
}
