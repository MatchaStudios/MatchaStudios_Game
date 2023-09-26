using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public GameObject bulletType;
    public float fireRate = 300.0f; // Rounds per minute
    public float bulletSpeed = 10f;
    public bool inheritVelocity = false;
    public float weaponDamage = 0f;

    public float shootRange = 100f;

    private float timeSinceFired;

    public Transform spawnPosition;

    public GameObject GameManager;
    ObjectPooling objectPooling;



    void Start()
    {
        GameManager = GameObject.Find("GameManager");
        if (GameManager != null)
        {
            objectPooling = GameManager.GetComponent<ObjectPooling>();
        }
    }

    void Update()
    {
        Targetting();
    }

    void Fire()
    {
        float interval = 1f / (fireRate / 60 /* seconds */);
        if(Time.time > timeSinceFired)
        {
            SpawnObject();  
            timeSinceFired = Time.time + interval;
        }
    }

    void Targetting()
    {
        Vector3 rayDirection = transform.forward;
        float rayLength = shootRange;
        int layerMask = 1 << LayerMask.NameToLayer("Bullet"); // Create a layer mask that only includes the "Bullet" layer.
        
        if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, rayLength, ~layerMask))
        {
            if (hit.collider.CompareTag("Player"))
            {
                Fire();
            }
        }
    }

    void SpawnObject()
    {
        // "spawns" bullet by setting to active.

        GameObject spawnedObject = objectPooling.GetObjectFromPool(bulletType.name);
        Debug.Log("Bullet Name: " + bulletType.name);

        if (spawnedObject != null)
        {
            if (spawnPosition == true)
            {
                spawnedObject.transform.position = spawnPosition.position;
                spawnedObject.transform.rotation = spawnPosition.rotation;
            }
            else
            {
                spawnedObject.transform.position = transform.position;
                spawnedObject.transform.rotation = Quaternion.identity;
            }
        }

        //Get Simple Bullet Script. Not every bullet has one!
         if (spawnedObject.TryGetComponent<SimpleBullet>(out SimpleBullet bullet))
        {
            bullet.Init();
            bullet.damage = weaponDamage;
            bullet.team = gameObject.tag;

            // Register the owner of the bullet
            bullet.objectSpawnedFrom = gameObject;
        }

        if (spawnedObject.TryGetComponent<Missile>(out Missile missile))
        {
            missile.Init();
        }

        // Shoots in the direction that the enemy is facing.
        // Every object should have transform.
        //spawnedObject.transform.rotation = transform.rotation;

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
