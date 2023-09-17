using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletType;
    private SimpleBullet simpleBullet;
    public float spawnRate = 1.0f; // Spawn once per second

    private float nextSpawnTime;

    void Start()
    {
        simpleBullet = bulletType.GetComponent<SimpleBullet>();
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
        //shoots in the direction that the enemy is facing.
        spawnedObject.transform.rotation = transform.rotation;
    }
}
