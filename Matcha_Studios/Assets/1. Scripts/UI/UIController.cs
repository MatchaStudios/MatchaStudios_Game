using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public Canvas canvas;

    public List<TargetIndicator> targetIndicators = new List<TargetIndicator>();

    public Camera MainCamera;

    public GameObject TargetIndicatorPrefab;
        public int indicatorCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(targetIndicators.Count > 0)
        {
            for(int i = 0; i < targetIndicators.Count; i++)
            {
                targetIndicators[i].UpdateTargetIndicator();
            }
        }
    }

    public void AddTargetIndicator(GameObject target)
    {
        indicatorCount = ++indicatorCount;
        target.GetComponent<TargetObject>().id = indicatorCount;
        TargetIndicator indicator = Instantiate(TargetIndicatorPrefab, canvas.transform).GetComponent<TargetIndicator>();
        indicator.InitialiseTargetIndicator(target, MainCamera, canvas, indicatorCount);
        target.GetComponent<TargetObject>().self = indicator;
        targetIndicators.Add(indicator);
    }
    public void RemoveTargetIndicator(GameObject target, int id)
    {
        if(targetIndicators.Find(x => x.id == id)){
        Destroy(targetIndicators.Find(x => x.id == id).gameObject);
        targetIndicators.RemoveAll(x => x.id == id);
        }
    }

}
