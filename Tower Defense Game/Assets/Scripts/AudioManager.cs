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
        //Ensures that this object carrys across scenes, while not duplicating
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
        //assigns both audio sources to their variable names
        AudioSource[] audios = GetComponents<AudioSource>();
        musicAudioSource = audios[0];
        sfxAudioSource = audios[1];

        buttonClick = _buttonClick;
    }
    void Update()
    {
        //while music is enabled, sets the volume of the audiosorce whis is playing music, to the volume determined by slider
        if (musicEnabled == 1)
        {
            musicAudioSource.volume = musicVolume;
        }
        //If sound is muted, volume of music is set to 0
        else if (musicEnabled == 0)
        {
            musicAudioSource.volume = 0f;
        }
        //adjusts the volume of the sound effects plaed when a button is pressed
        sfxAudioSource.volume = sfxVolume;
    }
    
    public void toggleMute ()
    {
        //When mute button is pressed, checks status of sfx and music and inverts it.
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
    //adjusts the volume of sfx and music via the option menu sliders
    public void adjSfxVolume(float newVol)
    {
        sfxVolume = newVol;
    }
    public void adjMusicVolume(float newMVol)
    {
        musicVolume = newMVol;
    }
    //can be called from anywhere to play the button sound. allows easy sfx for buton presses.
    public static void buttonSound ()
    {
        if (sfxEnabled == 1)
        {
            sfxAudioSource.PlayOneShot(buttonClick);
        }
    }
    
}
