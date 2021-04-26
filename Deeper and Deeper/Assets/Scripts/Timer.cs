using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    [SerializeField] float minutes = 10;
    [SerializeField] float seconds = 0;
    [SerializeField] Text displayTimer;
    private float remainingTime ;

    void Start() {
        remainingTime = minutes * 60 + seconds;
        
    }

    void Update()
    {
      
    }

    public void DisplayTime(float remainingTimeDisplayed)
    {
        remainingTimeDisplayed += 1;
        
        float minutes = Mathf.FloorToInt(remainingTimeDisplayed / 60); 
        float seconds = Mathf.FloorToInt(remainingTimeDisplayed % 60);

        displayTimer.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}