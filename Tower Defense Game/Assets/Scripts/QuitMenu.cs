using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenu : MonoBehaviour
{
    public GameObject ExitGameUI;
    public GameObject PastUI;
    //called from any quit button in game, opens teh quit menu overlay which asks the user if they are sure they want to quit.
    //will also hide the previous overlay or ui elemnts for a cleaner look
    public void QuitPanel ()
    {
        AudioManager.buttonSound();
        ExitGameUI.SetActive(true);
        PastUI.SetActive(false);
    }
    //called from nope button in quit menu overlay, returns to previous screen/menu
    public void Cancel ()
    {
        AudioManager.buttonSound();
        ExitGameUI.SetActive(false);
        PastUI.SetActive(true);     
    }
    //called from quit button in quit menu overlay, quits the application
    public void Quit ()
    {
        AudioManager.buttonSound();
        Debug.Log ("Quitting Game...");
        Application.Quit();
    }
}
