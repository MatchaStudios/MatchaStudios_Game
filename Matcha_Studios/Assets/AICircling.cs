using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICircling : MonoBehaviour
{
    public Pathfind pathfind;

    public float orbitSpeed = 3.0f;

    private Transform player;
    private float stoppingDistance;

    private Vector3 initialOffset;


    void Start()
    {
        pathfind = pathfind.GetComponent<Pathfind>();
        stoppingDistance = pathfind.stoppingDistance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        float distance = Vector3.Distance(transform.position, player.position);
        transform.LookAt(player);

        if (distance < stoppingDistance)
        {
            pathfind.enabled = false;
            initialOffset = transform.position - player.position;
            MakeAgentsCircleTarget();
        }
        else
        {
            pathfind.enabled = true;
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward) * distance;
        //Draws ray for visual debug purposes.
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    private void MakeAgentsCircleTarget()
    {
        // Calculate the new position based on the center object, radius, and time.
        float angle = Time.deltaTime * orbitSpeed; 
        Vector3 offset = Quaternion.Euler(0, angle, 0) * initialOffset;
        transform.position = player.position + offset;
    }
}
