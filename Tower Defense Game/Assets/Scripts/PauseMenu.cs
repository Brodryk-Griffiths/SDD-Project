using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject UICanvas;
    //called from pause button, stops time, hides pause and mute buttons and opens pause menu overlay
    public void Pause ()
    {
        AudioManager.buttonSound();
        pauseMenuUI.SetActive(true);
        UICanvas.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    //inverse of pause, called from resume button in pause menu
    public void Resume ()
    {
        AudioManager.buttonSound();
        pauseMenuUI.SetActive(false);
        UICanvas.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
}
