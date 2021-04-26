using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;

public class SelfCareActivityLoader : MonoBehaviour
{
    [SerializeField] private SelfCareActivityList selfCareActivityList;
    [SerializeField] private string pathToActivityList;

    void Start() {
           
    }

    public void LoadActivities() {
        using (StreamReader stream = new StreamReader(pathToActivityList))
        {
            string json = stream.ReadToEnd();
            selfCareActivityList = JsonUtility.FromJson<SelfCareActivityList>(json);
        }

        Debug.Log("ACTIVITIES LOADED : " + selfCareActivityList.selfCareActivities.Length);
        Debug.Log(selfCareActivityList.ToString());
    }

    public SelfCareActivity GetRandomActivity(){
        return selfCareActivityList.GetRandomActivity();
    }
}