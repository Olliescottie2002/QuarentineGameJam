using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    public TextMeshProUGUI timeText;
    public int startTime;
    private int currentTime;
    public int redDuration;


    private void Start()
    {
        currentTime = startTime;
        timeText.text = currentTime.ToString();
        StartCoroutine(timeDecrease());
    }

    private IEnumerator timeDecrease()
    {
        yield return new WaitForSeconds(1.0f);
        timeText.gameObject.SetActive(true);
        currentTime -= 1;

        int firstPart = currentTime / 60;
        string stringFirstPart = firstPart.ToString().Substring(0,1);
        int firstNum = Convert.ToInt32(stringFirstPart);
        int secondPart = currentTime % 60;

        if(secondPart == 0)
        {
            StartCoroutine(flashRed(redDuration));
        }

        if(secondPart < 10)
        {
            string timeSentence = firstPart.ToString() + ":0" + secondPart.ToString();
            timeText.text = timeSentence;
        }
        else
        {
            string timeSentence = firstPart.ToString() + ":" + secondPart.ToString();
            timeText.text = timeSentence;
        }

        if(currentTime <= 0)
        {
            print("GAME OVER, YOU LOSE!");
        }
        else
        {
            StartCoroutine(timeDecrease());
        }
    }

    private IEnumerator flashRed(int timeDelay)
    {
        timeText.color = Color.red;
        yield return new WaitForSeconds(timeDelay);
        timeText.color = Color.white;
    }
}
