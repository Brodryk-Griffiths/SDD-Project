using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousScore : MonoBehaviour
{
    public Text score;

    void Update()
    {
        score.text = ScoreStore.instance.getPreviousScoreText();
    }
}
