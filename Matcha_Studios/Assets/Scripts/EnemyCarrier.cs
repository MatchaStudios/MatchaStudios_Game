using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
 * Brief
 * spawns small heat seeking kamikaze enemies that can be destroyed in shoot script.
 * Buzzing bahaviour.
 */
public class EnemyCarrier : MonoBehaviour
{
    public float buzzingFrequency = 2.0f; // Adjust the frequency of the buzzing motion
    public float buzzingAmplitude = 0.5f; // Adjust the magnitude of the buzzing motion
    public float buzzingSpeed = 1.0f; // Adjust the speed of the buzzing motion 

    private Vector3 initialPosition;

    private Pathfind pathfind;
    private float stoppingDistance;

    void Start()
    {
        pathfind = this.gameObject.GetComponent<Pathfind>();
        stoppingDistance = pathfind.stoppingDistance;
    }

    void Update()
    {
        initialPosition = transform.position;

        float distance = Vector3.Distance(transform.position, pathfind.player.position);
        if (distance < stoppingDistance)
        {
            // Calculate buzzing motion using sine and cosine functions.
            float xOffset = Mathf.Sin(Time.time * buzzingFrequency * buzzingSpeed) * buzzingAmplitude;
            float yOffset = Mathf.Cos(Time.time * buzzingFrequency * buzzingSpeed) * buzzingAmplitude;

            // Apply buzzing motion to enemy's position.
            transform.position = initialPosition + new Vector3(xOffset, yOffset, 0);
        }

    }
}