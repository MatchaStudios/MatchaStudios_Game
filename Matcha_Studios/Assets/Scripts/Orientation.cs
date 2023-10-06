using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientation : MonoBehaviour
{
    Transform player;
    public float OrientationSpeed = 2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void ChangeOrientation()
    {
        if (player == null)
            player = GameObject.FindGameObjectWithTag("Player").transform;


        // Get the direction to the player
        Vector3 directionToPlayer = player.position - transform.position;

        // Ensure the enemy rotates only around its forward axis
        Quaternion targetRotation = Quaternion.LookRotation(directionToPlayer, player.transform.up);

        // Smoothly rotate the enemy towards the player
        float rotationSpeed = OrientationSpeed; // Adjust as needed
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    // Update is called once per frame
    void Update()
    {
        ChangeOrientation();
    }
}
