using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveObject : MonoBehaviour
{
    public int id = 0;
    private ObjectiveUIController ui;
    public  ObjectiveIndicator self;
    private void OnEnable()
    {
        ui = GetComponentInParent<ObjectiveUIController>();
        if (ui == null)
        {
            ui = GameObject.Find("ObjectiveCanvas").GetComponent<ObjectiveUIController>();
        }

        if (ui == null) Debug.LogError("No ObjectiveUIController component found");

        ui.AddTargetIndicator(this.gameObject);

    }
    private void OnDisable()
    {
        Debug.Log("Objective " + gameObject.name + " Removed");
        ui.RemoveTargetIndicator(this.gameObject, this.id);
        self.DeleteSelf();
    }
}
