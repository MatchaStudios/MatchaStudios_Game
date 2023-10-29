using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFix : MonoBehaviour
{
    GameObject camera_;
    void Start()
    {
        camera_ = GameObject.FindGameObjectWithTag("MainCamera");
        camera_.SetActive(false);
        camera_.SetActive(true);
    }
}
