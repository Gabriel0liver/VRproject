using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SetTimer : MonoBehaviour
{
    private float time = 30f; 
    public TextMeshProUGUI timerText;
    // Start is called before the first frame update
    void Start()
    {
        updateText();
    }

    public void increaseTime()
    {
        time += 30f;
        updateText();
    }

    public void decreaseTime()
    {
        if(time > 30)
        {
            time -= 30f;
        }
        updateText();
    }

    private void updateText()
    {
        int minutes = Mathf.FloorToInt(time / 60);
        int seconds = Mathf.FloorToInt(time % 60);
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public float getTime()
    {
        return time;
    }
}
