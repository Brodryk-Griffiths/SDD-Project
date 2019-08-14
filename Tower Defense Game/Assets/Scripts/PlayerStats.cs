using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    public Text PlayerMoneyText;
    public Text PlayerHealthText;
    public static float Money = 0f;
    public float startMoney = 180;
    public int PlayerHealth = 100;
    public static PlayerStats instance;
    void Awake ()
    {
        instance = this;
    }
    void Start ()
    {
        Money = startMoney;
    }

    void Update ()
    {
        //Used to display stats on UI
        PlayerMoneyText.text = "Player Money: $" + Money.ToString();
        PlayerHealthText.text = "Health: " + PlayerHealth.ToString();

        if (PlayerHealth <= 0)//may skip zero ie take 2 hp when only have 1 remaining so cannot be == 0
        {
            //Loads the Game over scene when player loses all their lives
            SceneManager.LoadScene("Game_Over");
        }
    }
}
