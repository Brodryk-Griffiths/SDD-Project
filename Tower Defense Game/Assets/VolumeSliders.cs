using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSliders : MonoBehaviour
{
    public static float newSfxVolume;
    public Slider sfxSlider;
    public Slider musicSlider;


    AudioManager audioManager;

    void Start ()
    {
        audioManager = AudioManager.instance;
        sfxSlider.value = AudioManager.sfxVolume;
        musicSlider.value = AudioManager.musicVolume;
    }
    public void AdjustSfxVolume (float sldSfxVolume)
    {
        audioManager.adjSfxVolume(sldSfxVolume);
    }
    public void AdjustMusicVolume (float sldMusicVolume)
    {
        audioManager.adjMusicVolume(sldMusicVolume);
    }
}
