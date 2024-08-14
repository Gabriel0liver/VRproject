using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    private float accuracy = 0;
    private float dodged = 0;
    private float hit = 0;

    public TextMeshProUGUI hitText;
    public TextMeshProUGUI dodgedText;
    public TextMeshProUGUI accuracyText;

    public void resetValues()
    {
        accuracy = 100;
        dodged = 0;
        hit = 0;
        writeScore();
    }

    public void hitWall(){
        dodged ++;
        calculateAccuracy();
    }

    public void hitPlayer()
    {
        hit++;
        calculateAccuracy();
    }

    private void calculateAccuracy()
    {
        accuracy = (dodged / (hit + dodged)) * 100;
        writeScore();
    }

    private void writeScore()
    {
        dodgedText.text = "boxes dodged: " + (int)dodged;
        hitText.text = "boxes hit: " + (int)hit;
        accuracyText.text = "accuracy: " + (int)accuracy + "%";
    }
}
