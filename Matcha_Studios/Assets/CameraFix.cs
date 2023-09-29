using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix : MonoBehaviour
{
    public GameObject cameraSibal;
    void Start()
    {
        cameraSibal = GameObject.FindGameObjectWithTag("MainCamera");
        cameraSibal.SetActive(false);
        cameraSibal.SetActive(true);
    }
}
