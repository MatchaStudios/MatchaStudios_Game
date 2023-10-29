using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ObjectiveTrigger : MonoBehaviour
{
    public bool collOn;
    public static Action markerEntered;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// OnTriggerEnter is called when the Collider other enters the trigger.
    /// </summary>
    /// <param name="other">The other Collider involved in this collision.</param>
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && collOn)
        markerEntered?.Invoke();
        //gameObject.SetActive(false);
    }
}
