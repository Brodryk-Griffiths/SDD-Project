using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static int sfxEnabled = 1;
    public static int musicEnabled = 1;

    public static float sfxVolume = 1f;
    public static float musicVolume = 1f;
    private AudioSource musicAudioSource;
    
    
    public static AudioManager instance;

    void Awake ()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    void Start()
    {
        musicAudioSource = GetComponent<AudioSource>();
    }
    void Update()
    {
        musicAudioSource.volume = musicVolume;
    }
    
    public void toggleMute ()
    {
        if (sfxEnabled == 1)
        {
            sfxEnabled -= 1;
            return;
        }
        else if (sfxEnabled == 0)
        {
            sfxEnabled += 1;
            return;
        }
        if (musicEnabled == 1)
        {
            musicEnabled -= 1;
            return;
        }
        else if (musicEnabled == 0)
        {
            musicEnabled += 1;
            return;
        }
    }
    public void adjSfxVolume(float newVol)
    {
        sfxVolume = newVol;
    }
    public void adjMusicVolume(float newMVol)
    {
        musicVolume = newMVol;
    }
    
    
    
}
