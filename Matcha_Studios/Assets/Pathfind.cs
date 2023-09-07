using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfind : MonoBehaviour
{
    public float moveSpeed = 10.0f;
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
        // Add logic for following the player and stopping within vicinity.
        // You'll use Vector3.MoveTowards or a similar function.
        // Add logic for avoiding other AIs.

        float distance = Vector3.Distance(transform.position, player.position);

        if (distance > stoppingDistance)
        {
            transform.LookAt(player);
            transform.position = Vector3.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
    }
    void AvoidCollision()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 5.0f))
        {
            if (hit.collider.CompareTag("AI"))
            {
                // Adjust path to avoid collision with other AI.
                // AI pathfinding.

            }
        }
    }

}
