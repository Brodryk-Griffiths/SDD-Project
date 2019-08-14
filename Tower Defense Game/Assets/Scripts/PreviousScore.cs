using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviousScore : MonoBehaviour
{
    public Text score;
    //simply saves the highest wave to display on game over and main menu
    void Update()
    {
        score.text = ScoreStore.instance.getPreviousScoreText();
    }
}
