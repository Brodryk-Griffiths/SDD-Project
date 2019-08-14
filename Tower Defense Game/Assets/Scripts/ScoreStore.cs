using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStore : MonoBehaviour
{
    public static ScoreStore instance;
    public int waveCount;
    private string previousScore;
    
    //Ensures that this object carrys across scenes, while not duplicating
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
        waveCount = 0;
    }
    //can be called to access the previous score string
    public string getPreviousScoreText()
    {
        return previousScore;
    }
    //called from wave spawner scriot when new wave button pressed, storing current wave
    public void addWaveCount(int count)
    {
        waveCount = count;
    }
    //creates a string which is accesed by PreviousScore script to display
    void Update ()
    {
        previousScore = "Your last score was wave " + waveCount.ToString() + "!";
    }
}
