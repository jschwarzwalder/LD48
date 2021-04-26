using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

[Serializable]
public class SelfCareActivityList {
    
    public SelfCareActivity[] selfCareActivities;

    public SelfCareActivity GetRandomActivity(){
        
        return selfCareActivities[UnityEngine.Random.Range(0, selfCareActivities.Length)];
    }

    public override string ToString() {
        string activityPrint = "SELF CARE ACTIVITIES\n";

        foreach (var activity in selfCareActivities) {
            activityPrint += string.Format("Name: {0}\nTime: {1}:{2}\nPath: {3}\n\n",
            activity.name, activity.timeMinutes, activity.timeSeconds, activity.pathToAudio);
        }

        return activityPrint;
    }
}   