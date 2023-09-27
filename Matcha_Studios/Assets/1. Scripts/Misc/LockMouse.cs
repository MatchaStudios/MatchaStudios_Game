using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockMouse : MonoBehaviour
{
    private void Awake() {
        
        
    }
    // Start is called before the first frame update
    void Start()
    {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
    }

    void OnApplicationFocus(bool hasFocus)
    {
        if (hasFocus)
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            Debug.Log("Application is focussed");
        }
        else
        {
            Debug.Log("Application lost focus");
        }
    }

    // Update is called once per frame
    void Update()
    {
       // Debug.Log(Cursor.lockState.ToString());
    }
}
