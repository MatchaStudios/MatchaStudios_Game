using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using UnityEngine;

public class ObjectiveManager : MonoBehaviour
{
    public List<GameObject> objectives = new List<GameObject>();
    public int currentObjective= 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnEnable() {
        ObjectiveTrigger.markerEntered +=UpdateObjectives;
    }
    private void OnDisable() {
        ObjectiveTrigger.markerEntered -=UpdateObjectives;
    }

    public void UpdateObjectives () {
        if(currentObjective == 0)
        {
            objectives[0].SetActive(false);
            objectives[1].SetActive(true);
            
        }
        else
        {
            objectives[1].SetActive(false);
            objectives[2].SetActive(true);
        }
        currentObjective++;
    }
}
