using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AICircling : MonoBehaviour
{
    public float orbitSpeed = 3.0f;

    private Transform player;

    public Pathfind pathfind;
    private float stoppingDistance;

    private Vector3 initialOffset;
    Rigidbody rb;

    void Start()
    {
        pathfind = pathfind.GetComponent<Pathfind>();
        stoppingDistance = pathfind.stoppingDistance;
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if(player == null)
        {
            return;
        }

        float distance = Vector3.Distance(transform.position, player.position);
        //pathfind.enabled = false;
        ////initialOffset = transform.position - player.position;
        //MakeAgentsCircleTarget();

        if (distance < stoppingDistance)
        {
            pathfind.enabled = false;
            //initialOffset = transform.position - player.position;
            MakeAgentsCircleTarget();
        }
        else
        {
            pathfind.enabled = true;
            rb.velocity = Vector3.zero;
        }

        Vector3 forward = transform.TransformDirection(Vector3.forward) * distance;
        //Draws ray for visual debug purposes.
        Debug.DrawRay(transform.position, forward, Color.green);
    }

    private void MakeAgentsCircleTarget()
    {
        // Calculate the new position based on the center object, radius, and time.
        //float angle = Time.deltaTime * orbitSpeed; 
        //Vector3 offset = Quaternion.Euler(0, angle, 0) * initialOffset;
        //transform.position = player.position + offset;

        // float centripetalForce = 1;// rb.mass * orbitSpeed * orbitSpeed * stoppingDistance;
        // rb.AddForce(centripetalForce * transform.forward, ForceMode.Impulse);
        rb.velocity = orbitSpeed * Vector3.Cross(player.transform.up, transform.forward);
    }
}
