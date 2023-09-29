using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfind : MonoBehaviour
{
    [Range(0, 1)]
    public float moveSpeed = 0.1f;
    [Range(0, 1)]
    public float avoidSpeedPercentage = 0.5f;

    public float avoidSpeed = 10f;
    public float stoppingDistance = 2.0f;
    public float lookAtSpeed = 1.0f;
    public float lookAtAngle;
    public Transform player;

    // Rays
    public int rayCount = 10; // Number of rays to emit
    public float rayLength = 5.0f; // Length of each ray
    public float spreadAngle = 45.0f; // Angle of spread in degrees

    // rigidbody
    public Rigidbody rb;

    public bool targetting;

    // State
    public enum State
    {
        TARGET,
        AVOID
    }

    public State state = State.TARGET;

    void Start()
    {
        // Find the player using a tag.
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();

        // match with player's rotation.
        transform.rotation = player.transform.rotation;
    }

    void Update()
    {
        // check if player still exists
        if (player == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);

        //to use for drawing raycast.
        Vector3 forward = transform.TransformDirection(Vector3.forward) * distance;

        AvoidCollision();
        
        Orientation();

        switch (state)
        {
            case State.TARGET:
                // transform.LookAt(player);
                Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position, transform.up);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookAtSpeed * Time.deltaTime);
                if (distance > stoppingDistance)
                {
                    SmoothMoveTowards(player.position, moveSpeed);
                }
                break;

            case State.AVOID:
                break;
        }


        //Draws ray for visual debug purposes.
        Debug.DrawRay(transform.position, forward, Color.green);

    }

    void SmoothMoveTowards(Vector3 targetPosition, float speed)
    {
        // Calculate the step size based on speed and frame rate.
        float step = speed * Time.deltaTime;

        // Move towards the target using Vector3.Lerp.
        transform.position = Vector3.Lerp(transform.position, targetPosition, step);
    }

    void AvoidCollision()
    {

        for (int i = 0; i < rayCount; i++)
        {
            float angle = (i / (float)(rayCount - 1) - 0.5f) * spreadAngle;
            Quaternion rotation = Quaternion.AngleAxis(angle, transform.up);

            Vector3 rayDirection = rotation * transform.forward;
            Vector3 rayOrigin = transform.position;

            Debug.DrawRay(rayOrigin, rayDirection * rayLength, Color.cyan);

            float distance = Vector3.Distance(transform.position, player.position);

            //RaycastHit hit;
            if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, rayLength))
            {
                if (hit.collider.CompareTag("Environment"))
                {
                    targetting = false;

                    state = State.AVOID;
                    Vector3 ObstacleNormal = hit.normal;
                    Vector3 direction = (hit.point - transform.position).normalized;
                    Vector3 dirToGo = Vector3.Cross(ObstacleNormal, direction);
                    rb.AddForce(avoidSpeed * dirToGo.normalized, ForceMode.Impulse);
                    Debug.DrawRay(hit.point, 10 * ObstacleNormal, Color.yellow); // Normal to surface
                    Debug.DrawRay(transform.position, 10 * dirToGo.normalized, Color.red); // Direction to change to
                }
            }
            else if (distance > stoppingDistance)
            {
                targetting = true;

                state = State.TARGET;
            }
        }

    }

    void Orientation()
    {
         // Get the direction to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Ensure the enemy rotates only around its forward axis
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, player.transform.up);

        // Smoothly rotate the enemy towards the player
        float rotationSpeed = 2.0f; // Adjust as needed
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

}
