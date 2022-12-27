using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreBoard : ProjectBehavior
{
    int score;
    [SerializeField] TMP_Text scoreOnHUD;

    public void IncreaseScore(int amountToIncreaseScore)
    {
        score += amountToIncreaseScore;

        UpdateScore();
    }

    void UpdateScore()
    {
        scoreOnHUD.text = "SCORE: " + score;
    }
}
