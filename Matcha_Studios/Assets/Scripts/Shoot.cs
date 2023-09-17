using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletType;
    public float spawnRate = 1.0f; // Spawn once per second
    public float bulletSpeed = 10f; 
    private float nextSpawnTime;

    public bool inheritVelocity = false;

    void Start()
    {
        nextSpawnTime = Time.time + spawnRate;
    }

    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            SpawnObject();
            nextSpawnTime = Time.time + spawnRate;
        }
    }

    void SpawnObject()
    {
        GameObject spawnedObject = Instantiate(bulletType, transform.position, Quaternion.identity);
        // shoots in the direction that the enemy is facing.
        spawnedObject.transform.rotation = transform.rotation;

        // Get rigidbody of the spawned bullet.
        Rigidbody rb = spawnedObject.GetComponent<Rigidbody>();

        if(inheritVelocity == true)
        {
            // inherit velocity from this gameObject.
            rb.velocity = this.GetComponent<Rigidbody>().velocity;
        }

        // shoot the bullet in the direction of the target.
        rb.velocity += bulletSpeed * transform.forward;

    }
}
