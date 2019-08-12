using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretSellAudio : MonoBehaviour
{
    
    private static AudioSource audioSource;
    
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.volume = AudioManager.sfxVolume;

    }

    public static void sellEffect (AudioClip sound)
    {
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
