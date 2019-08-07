using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject UICanvas;
    void Update()
    {
        
    }

    public void Pause ()
    {
        pauseMenuUI.SetActive(true);
        UICanvas.SetActive(false);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        UICanvas.SetActive(true);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Menu ()
    {
        SceneManager.LoadScene("Main Menu");
        Time.timeScale = 1f;
    }
}
