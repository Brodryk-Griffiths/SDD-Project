using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{

    public GameObject returnToMenuUI;

    public GameObject PastUI;
    public GameObject GameUI;
    
    
    public void ReturnToMenuPanel ()
    {
        AudioManager.buttonSound();
        returnToMenuUI.SetActive(true);
        PastUI.SetActive(false);
    }
    
    public void Cancel ()
    {
        AudioManager.buttonSound();
        returnToMenuUI.SetActive(false);
        PastUI.SetActive(true);     
    }

    public void Quit ()
    {
        AudioManager.buttonSound();
        GameUI.SetActive(true);
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
}
