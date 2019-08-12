using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenu : MonoBehaviour
{

    public GameObject ExitGameUI;
    public GameObject PastUI;
    
        public void QuitPanel ()
    {
        AudioManager.buttonSound();
        ExitGameUI.SetActive(true);
        PastUI.SetActive(false);
    }
    
        public void Cancel ()
    {
        AudioManager.buttonSound();
        ExitGameUI.SetActive(false);
        PastUI.SetActive(true);     
    }

    public void Quit ()
    {
        AudioManager.buttonSound();
        Debug.Log ("Quitting Game...");
        Application.Quit();
    }
}
