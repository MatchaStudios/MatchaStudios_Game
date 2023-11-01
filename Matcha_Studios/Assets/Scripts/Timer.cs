using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Count Down
public class Timer : MonoBehaviour
{
    [Header("=== Enemy Timer ===")]
    public float time = 0f;
    public float timerSet = 10f;
    private bool timeStop = false;
    public Timer GetTimer()
    {
        return this;
    }

    public bool GetTimerStopped()
    {
        return timeStop;
    }


    // Start is called before the first frame update
    void Awake()
    {
        time = timerSet;
        timeStop = false;
    }

    // Update is called once per frame
    void Update()
    {

    }
    
    public void UpdateTimer()
    {
        if (time >= 0)
        {
            time -= Time.deltaTime;
        }
        else
        {
            timeStop = true;
        }
    }

    public void ResetTimer()
    {
        time = timerSet;
        timeStop = false;
    }
}
