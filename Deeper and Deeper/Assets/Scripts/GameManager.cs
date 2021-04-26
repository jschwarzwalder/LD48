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
    [SerializeField] AudioSource guidedInstructionsSource;
    [SerializeField] SelfCareActivityLoader selfCareActivities;
    [SerializeField] AudioClip[] guidedInstructions;
    
    private float remainingTime;
    private bool timerActive = false;
    private bool coolDown = false;
    private Dictionary<string, AudioClip> guidedInstructionsMap = new Dictionary<string, AudioClip>();

    // Start is called before the first frame update
    void Start()
    {
        selfCareActivities.LoadActivities();
        currentLevel = 0;
        remainingTime  = 30;
        timerActive = false;
        coolDown = true;
        timer.GetComponent<Timer>().DisplayText("Welcome!");
        levelDisplay.text = "Complete Self Care Activities to gain levels.";
        levelDisplay.fontSize = 24;
        foreach (AudioClip audio in guidedInstructions) {
            Debug.Log(string.Format("Adding AudioClip {0} to Map", audio.name));
            guidedInstructionsMap.Add(audio.name, audio); 
        }

    }

    // Update is called once per frame
    void Update()
    {
         if (timerActive || coolDown)
        {
             if (remainingTime > 0)
            {
                remainingTime -= Time.deltaTime;
                 if (timerActive){
                    timer.GetComponent<Timer>().DisplayTime(remainingTime);
                } else {
                    timer.GetComponent<Timer>().DisplayText("Waiting for Next Activity");
                }
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
                guidedInstructionsSource.clip = guidedInstructionsMap[activity.pathToAudio];
                timerActive = true;
                coolDown = false;
                currentLevel += 1;
                levelDisplay.fontSize = 36;
                levelDisplay.text = string.Format("Level {0}", currentLevel.ToString());
                guidedInstructionsSource.Play();
               }
            }   
        }
    }


}
