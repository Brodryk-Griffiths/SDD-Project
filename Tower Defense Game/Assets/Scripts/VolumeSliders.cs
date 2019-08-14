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
        //gets values of current audio levels and sets the slider to match that position
        sfxSlider.value = AudioManager.sfxVolume;
        musicSlider.value = AudioManager.musicVolume;
    }
    //Sliders provide a new float value when moved. this value is then passed into its respective function where it adjusts the value in the audiomanager script
    public void AdjustSfxVolume (float sldSfxVolume)
    {
        audioManager.adjSfxVolume(sldSfxVolume);
        AudioManager.buttonSound();
    }
    public void AdjustMusicVolume (float sldMusicVolume)
    {
        audioManager.adjMusicVolume(sldMusicVolume);
        AudioManager.buttonSound();
    }
}
