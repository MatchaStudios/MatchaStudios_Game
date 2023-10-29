using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotating : MonoBehaviour
{
    public float rotationSpeed = 1.0f;

    void Update()
    {
        // Rotate around the y-axis
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
}
