using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spin : MonoBehaviour
{
    public float xAngle, yAngle, zAngle;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(xAngle*Time.deltaTime, yAngle*Time.deltaTime, zAngle*Time.deltaTime, Space.Self);
    }
}
