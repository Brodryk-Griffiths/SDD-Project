using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteState : MonoBehaviour
{
    private int buttonMute = 1;
    public GameObject buttonMuted;
    public GameObject buttonUnmuted;
    AudioManager audioManager;
    void Start()
    {
        audioManager = AudioManager.instance;
    }
    public void flipButtonThing()
    {
        audioManager.toggleMute(); 
        if (buttonMute == 0)
        {
            buttonUnmuted.SetActive(true);
            buttonMuted.SetActive(false);
            buttonMute += 1;
        }
        else if (buttonMute == 1)
        {
            buttonMuted.SetActive(true);
            buttonUnmuted.SetActive(false);
            buttonMute -= 1;
        }
        
        Debug.Log(buttonMute);
    }
}
