using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    public Text PlayerMoneyText;
    public static int Money;
    public int startMoney = 400;

    void Start ()
    {
        Money = startMoney;
    }

    void Update ()
    {
        PlayerMoneyText.text = "Player Money: $" + Money.ToString();
    }
}
