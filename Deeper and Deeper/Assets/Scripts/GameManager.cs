using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int currentLevel = 0;

    [SerializeField] GameObject Timer;
    [SerializeField] Text ActivityName;
    [SerializeField] Text LevelDisplay;
    [SerializeField] SelfCareActivityLoader selfCareActivities;

    // Start is called before the first frame update
    void Start()
    {
        selfCareActivities.LoadActivities();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
