using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int currentLevel = 0;

    [SerializeField] GameObject timer;
    [SerializeField] float coolDownTime;
    [SerializeField] Text activityName;
    [SerializeField] Text levelDisplay;
    [SerializeField] SelfCareActivityLoader selfCareActivities;
    
    private float remainingTime;
    private bool timerActive = false;
    private bool coolDown = false;

    // Start is called before the first frame update
    void Start()
    {
        selfCareActivities.LoadActivities();
        currentLevel = 0;
        remainingTime  = 2 * 60;
        timerActive = false;
        coolDown = true;
    }

    // Update is called once per frame
    void Update()
    {
         if (timerActive || coolDown)
        {
             if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
            }
            
             if (timerActive){
                    timer.GetComponent<Timer>().DisplayTime(remainingTime);
                }
            else
            {
               if (timerActive){
                timerActive = false;
                coolDown = true;
                remainingTime = coolDownTime;
                Debug.Log("Time has run out!");
               }
               if (coolDown){
                SelfCareActivity activity =  selfCareActivities.GetRandomActivity();
                activityName.text = activity.name;
                remainingTime = float.Parse(activity.timeMinutes) * 60 +  float.Parse(activity.timeSeconds);
                timerActive = true;
                coolDown = false;
                currentLevel += 1;
                levelDisplay.text = string.Format("Level {0}", currentLevel.ToString());
               }
            }   
        }
    }


}
