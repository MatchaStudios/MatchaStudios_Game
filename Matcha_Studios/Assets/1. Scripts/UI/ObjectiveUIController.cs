using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveUIController : MonoBehaviour
{
    public Canvas canvas;

    public List<ObjectiveIndicator> objectiveIndicators = new List<ObjectiveIndicator>();

    public Camera MainCamera;

    public GameObject TargetObjectivePrefab;
    public int indicatorCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(objectiveIndicators.Count > 0)
        {
            for(int i = 0; i < objectiveIndicators.Count; i++)
            {
                objectiveIndicators[i].UpdateTargetIndicator();
            }
        }
    }

    public void AddTargetIndicator(GameObject target)
    {
        indicatorCount = ++indicatorCount;
        target.GetComponent<ObjectiveObject>().id = indicatorCount;
        ObjectiveIndicator indicator = Instantiate(TargetObjectivePrefab, canvas.transform).GetComponent<ObjectiveIndicator>();
        indicator.InitialiseTargetIndicator(target, MainCamera, canvas, indicatorCount);
        target.GetComponent<ObjectiveObject>().self = indicator;
        objectiveIndicators.Add(indicator);
    }
    public void RemoveTargetIndicator(GameObject target, int id)
    {
        if(objectiveIndicators.Find(x => x.id == id)){
        Destroy(objectiveIndicators.Find(x => x.id == id).gameObject);
        objectiveIndicators.RemoveAll(x => x.id == id);
        }
    }
}
