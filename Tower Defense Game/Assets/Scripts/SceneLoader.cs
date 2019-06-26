using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void GoToLevel(string level)
    {
        SceneManager.LoadScene(level);
    }
}
