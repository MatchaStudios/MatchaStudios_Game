using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class AsteroidMovement : MonoBehaviour
{
    public float moveSpeed = 2.0f;

    public float leftBound = -5.0f;
    public float rightBound = 5.0f;

    private float lowerBound = -5.0f;
    private float upperBound = 5.0f;

    bool randomValue;

    public enum XAXIS {LEFT, RIGHT};
    public XAXIS xAXIS;

    public enum YAXIS { UP, DOWN };
    public YAXIS yAXIS;

    private void Start()
    {
        //generate whether it should move in x-dir or y-dir.
        bool[] coinFlip = { false, true };

        randomValue = coinFlip[UnityEngine.Random.Range(0, coinFlip.Length)];

        if(randomValue == true)
        {
            // if x-dir then generate random x-dir.
            xAXIS = GetRandomEnumValue<XAXIS>();
        }
        else
        {
            // if y-dir then generate random y-dir.
            yAXIS = GetRandomEnumValue<YAXIS>();
        }
    }

    void Update()
    {
        Debug.Log("Position: " + transform.position.x);

        if (randomValue == true)
            XDir();
        else
            YDir();
    }

    void XDir()
    {
        switch (xAXIS)
        {
            case XAXIS.LEFT:
                transform.Translate(-Vector3.right * moveSpeed * Time.deltaTime);
                if (transform.position.x < leftBound)
                {
                    xAXIS = XAXIS.RIGHT;
                }
                break;
            case XAXIS.RIGHT:
                transform.Translate(Vector3.right * moveSpeed * Time.deltaTime);
                if (transform.position.x > rightBound)
                {
                    xAXIS = XAXIS.LEFT;
                }
                break;
        }
    }
    void YDir()
    {
        switch (yAXIS)
        {
            case YAXIS.DOWN:
                transform.Translate(-Vector3.up * moveSpeed * Time.deltaTime);
                if (transform.position.y < lowerBound)
                {
                    yAXIS = YAXIS.UP;
                }
                break;
            case YAXIS.UP:
                transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
                if (transform.position.y > upperBound)
                {
                    yAXIS = YAXIS.DOWN;
                }
                break;
        }        
    }

    T GetRandomEnumValue<T>()
    {
        Array values = Enum.GetValues(typeof(T));
        int randomIndex = UnityEngine.Random.Range(0, values.Length);
        return (T)values.GetValue(randomIndex);
    }
}
