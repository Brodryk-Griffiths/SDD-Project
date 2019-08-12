using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    //Called from buttons to load a scene
    public void GoToLevel(string level)
    {
        AudioManager.buttonSound();
        SceneManager.LoadScene(level);
    }
}
