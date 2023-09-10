using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfind : MonoBehaviour
{
    [Range(0, 1)]
    public float moveSpeed = 0.1f;
    public float stoppingDistance = 2.0f;
    public Transform player;
    // Add any other variables you might need here.

    void Start()
    {
        // Find the player using a tag or some other method.
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stoppingDistance)
        {
            transform.LookAt(player);
            SmoothMoveTowards(player.position, moveSpeed);
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward) * distance;
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    void SmoothMoveTowards(Vector3 targetPosition, float speed)
    {
        // Calculate the step size based on speed and frame rate.
        float step = speed * Time.deltaTime;

        // Move towards the target using Vector3.Lerp.
        transform.position = Vector3.Lerp(transform.position, targetPosition, step);
    }

}
