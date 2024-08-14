using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ControlPanel : MonoBehaviour
{
    public Spawner spawner;
    ScoreManager scoreManager;

    public Slider speedSlider;
    public Slider intervalSlider;
    public TMP_Dropdown modeDropdown;
    public TextMeshProUGUI timeText;

    void Start()
    {
        scoreManager =FindAnyObjectByType<ScoreManager>();
    }
    void Update()
    {
        
    }

    public void startGeneration(){
        spawner.turnOn(speedSlider.value, intervalSlider.value, timeToFloat(timeText.text), modeDropdown.value);
        scoreManager.resetValues();
    }

    public float timeToFloat(string timerText)
    {
        string[] timeParts = timerText.Split(':');
        int minutes = int.Parse(timeParts[0]);
        float seconds = float.Parse(timeParts[1]);
        return minutes * 60 + seconds;
    }
}
