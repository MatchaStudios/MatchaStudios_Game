using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenShake : MonoBehaviour
{
public Transform cameraTransform;
    public float shakeDuration = 0.5f;
    public float shakeMagnitude = 0.1f;
    public float dampingSpeed = 1.0f;

    Vector3 initialPosition;
    float startTime;

    void Start()
    {
        if (cameraTransform == null)
        {
            cameraTransform = Camera.main.transform;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShakeCamera();
        }

        if (Time.time - startTime < shakeDuration)
        {
            Vector3 offset = Random.insideUnitSphere * shakeMagnitude;
            cameraTransform.localPosition = initialPosition + offset;
        }
        else
        {
            cameraTransform.localPosition = initialPosition;
        }
    }

    void ShakeCamera()
    {
        initialPosition = cameraTransform.localPosition;
        startTime = Time.time;
    }
}
