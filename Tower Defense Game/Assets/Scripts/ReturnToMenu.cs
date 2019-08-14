using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnToMenu : MonoBehaviour
{

    public GameObject returnToMenuUI;

    public GameObject PastUI;
    public GameObject GameUI;
    
    //refer to QuitMenu.cs as same logic
    public void ReturnToMenuPanel ()
    {
        AudioManager.buttonSound();
        returnToMenuUI.SetActive(true);
        PastUI.SetActive(false);
    }
    //refer to QuitMenu.cs as same logic
    public void Cancel ()
    {
        AudioManager.buttonSound();
        returnToMenuUI.SetActive(false);
        PastUI.SetActive(true);     
    }
    //loads the main menu scene, and resumes time, as this was called from pause menu where time had previously been stopped.
    public void Quit ()
    {
        AudioManager.buttonSound();
        GameUI.SetActive(true);
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
}
