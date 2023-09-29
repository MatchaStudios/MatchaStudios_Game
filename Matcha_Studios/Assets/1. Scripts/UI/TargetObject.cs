using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetObject : MonoBehaviour
{
    public int id = 0;
    private UIController ui;
    public  TargetIndicator self;
    private void Start()
    {
        ui = GetComponentInParent<UIController>();
        if (ui == null)
        {
            ui = GameObject.Find("TrackingCanvas").GetComponent<UIController>();
        }

        if (ui == null) Debug.LogError("No UIController component found");

        ui.AddTargetIndicator(this.gameObject);

    }
    private void OnDisable()
    {
        Debug.Log("Target " + gameObject.name + " Removed");
        ui.RemoveTargetIndicator(this.id);
        self.DeleteSelf();
    }
}
