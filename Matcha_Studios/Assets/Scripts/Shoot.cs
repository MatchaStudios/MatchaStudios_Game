using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject   bulletType;
    public float        spawnRate = 1.0f; // Spawn once per second
    public float        bulletSpeed = 10f; 
    public bool         inheritVelocity = false;
    public float        weaponDamage = 0f;

    private float       nextSpawnTime;

    public GameObject GameManager;
    ObjectPooling objectPooling;


    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        if (GameManager != null)
        {
            objectPooling = GameManager.GetComponent<ObjectPooling>();
        }

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
        // spawns bullet
        //GameObject spawnedObject = Instantiate(bulletType, transform.position, Quaternion.identity);

        GameObject spawnedObject = objectPooling.GetObjectFromPool(bulletType);

        if (spawnedObject != null)
        {
            spawnedObject.transform.position = transform.position;
            spawnedObject.transform.rotation = Quaternion.identity;
            spawnedObject.SetActive(true);
        }

        // Get Simple Bullet Script. Not every bullet has one!
        if (spawnedObject.TryGetComponent<SimpleBullet>(out SimpleBullet bullet))
        {
            bullet.damage = weaponDamage;
            bullet.team = gameObject.tag;
            bullet.objectSpawnedFrom = gameObject;
        }

        // Shoots in the direction that the enemy is facing.
        // Every object should have transform.
        spawnedObject.transform.rotation = transform.rotation;

        // Only works for capsule bullets, is incompatible with other bullets
        //spawnedObject.transform.Rotate(Vector3.right, 90.0f);

        // Get rigidbody of the spawned bullet. Not every bullet has one!
        if (spawnedObject.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            //rb = spawnedObject.GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;

            if (inheritVelocity == true)
            {
                // inherit velocity from this gameObject.
                rb.velocity = this.GetComponent<Rigidbody>().velocity;
            }

            // shoot the bullet in the direction of the target.
            // get the bullet's velocity to aim towards the player by using the AI's transform.
            // pushing the bullet out from the AI'S transform.forward instead of using the
            // bullet's transform.up.
            rb.velocity += bulletSpeed * transform.forward;
        }
    }
}
