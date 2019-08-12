using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static int sfxEnabled = 1;
    public static int musicEnabled = 1;

    public static float sfxVolume = 1f;
    public static float musicVolume = 0.15f;
    private AudioSource musicAudioSource;
    private static AudioSource sfxAudioSource;
    public static AudioClip buttonClick;    
    public AudioClip _buttonClick;
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
        AudioSource[] audios = GetComponents<AudioSource>();
        musicAudioSource = audios[0];
        sfxAudioSource = audios[1];

        buttonClick = _buttonClick;
    }
    void Update()
    {
        if (musicEnabled == 1)
        {
            musicAudioSource.volume = musicVolume;
        }
        else if (musicEnabled == 0)
        {
            musicAudioSource.volume = 0f;
        }
        
        sfxAudioSource.volume = sfxVolume;
    }
    
    public void toggleMute ()
    {
        if (sfxEnabled == 1)
        {
            sfxEnabled -= 1;
            
        }
        else if (sfxEnabled == 0)
        {
            sfxEnabled += 1;
            
        }
        if (musicEnabled == 1)
        {
            musicEnabled -= 1;
            
        }
        else if (musicEnabled == 0)
        {
            musicEnabled += 1;
            
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
    
    public static void buttonSound ()
    {
        if (sfxEnabled == 1)
        {
            sfxAudioSource.PlayOneShot(buttonClick);
        }
    }
    
}
