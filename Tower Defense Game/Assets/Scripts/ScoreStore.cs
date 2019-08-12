using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreStore : MonoBehaviour
{
    public static ScoreStore instance;
    public int waveCount;

    private string previousScore;

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

    public string getPreviousScoreText()
    {
        return previousScore;
    }
    public void addWaveCount(int count)
    {
        waveCount = count;
    }
    void Update ()
    {
        previousScore = "Your last score was wave " + waveCount.ToString() + "!";
    }
}
