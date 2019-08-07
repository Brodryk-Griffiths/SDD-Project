using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitMenu : MonoBehaviour
{

    public GameObject ExitGameUI;
    public GameObject PastUI;
    
        public void QuitPanel ()
    {
        ExitGameUI.SetActive(true);
        PastUI.SetActive(false);
    }
    
        public void Cancel ()
    {
        ExitGameUI.SetActive(false);
        PastUI.SetActive(true);     
    }

    public void Quit ()
    {
        Debug.Log ("Quitting Game...");
        Application.Quit();
    }
}
