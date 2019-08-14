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
    //function called when mute button is pressed
    public void flipButtonThing()
    {
        //Plays button sound and calls the toggle mute functon in the audiomanager, muting or unmuting all sounds.
        AudioManager.buttonSound();
        audioManager.toggleMute(); 
        //flips the icon on the button to represent whether or not sound is muted
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
    }
}
