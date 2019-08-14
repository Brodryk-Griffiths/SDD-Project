using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSellAudio : MonoBehaviour
{
    
    private static AudioSource audioSource;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        //sets volume per sfxVolume
        audioSource.volume = AudioManager.sfxVolume;

    }
    //plays a sound when called... called when a turret is sold
    public static void sellEffect (AudioClip sound)
    {
        //only plays a sound if sound not muted
        if (AudioManager.sfxEnabled == 1)
        {
            audioSource.PlayOneShot(sound);
        }
        else 
        {
            return;
        }
    }
}
