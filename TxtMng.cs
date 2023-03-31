using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;


public class TxtMng : MonoBehaviour
{
    public TMP_Text MatchTimerText;
    public TMP_Text ShotTimerText;


    public TMP_Text MassText;
    public TMP_Text VariableTText;
    public TMP_Text GravityText;
    public TMP_Text ConstantKText;
    public TMP_Text HeightTargetText;
    public TMP_Text HeightPlatformText;

    //canva2
    public TMP_Text ActualScore;
    public TMP_Text FinalScore;
    public TMP_Text Shots;

    public void SetTimerText(float matchTime, float shotTime)
    {
            MatchTimerText.text = "Match Time: " + Math.Round(matchTime);
            ShotTimerText.text  = "Shot Time: "  + Math.Round(shotTime);
    }

    public void SetValuesText(float prjMass, float t, float grvt, float k, float trgrHgt, float platHgt)
    {
        MassText.text           = "Mass = "            + prjMass;
        GravityText.text        = "Gravity = "         + grvt;
        VariableTText.text      = "Variable T = "      + t;
        ConstantKText.text      = "Constante K = "     + k;
        HeightTargetText.text   = "Height target = "   + trgrHgt;
        HeightPlatformText.text = "Height platform = " + platHgt;
    }

    public void SetScoreText(int score)
    {
        ActualScore.text = "Score = " + score;
        FinalScore.text = "Final Score = " + score;
    }

    public void SetShotText(int shots)
    {
        Shots.text = "Total Shots = " + shots;
    }
}
