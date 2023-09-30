using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // bullet
    [Header("=== Weapon Properties ===")]
    public GameObject bulletType;
    public float fireRate = 300.0f; // Rounds per minute
    public float bulletSpeed = 10f;
    public bool inheritVelocity = false;
    public float weaponDamage = 0f;

    // Range at which enemy starts shooting
    // Determines Raycast length in code

    [Header("=== Range To Shoot ===")]
    public float minShootRange = 0f;
    public float maxShootRange = 100f;

    [SerializeField]
    private float distanceFromTarget = 0f;

    private float timeSinceFired;

    [Header("=== Spawn Position ===")]
    public Transform spawnPosition;

    [Header("=== Object Pooling Reference ===")]
    public GameObject GameManager;
    ObjectPooling objectPooling;

    [Header("=== Enemy Target Prediction ===")]
    // Velocities of player which enemy will shoot
    public float lowerPlayerSpeed = 1;
    public float upperPlayerSpeed = 10;

    // Leading speed
    // public float lookAtSpeed = 0.1f;

    // find the player
    Transform player;
    public float timeAhead = 0.5f; // Adjust as needed

    // Read Only Field
    [SerializeField]
    private float playerSpeed = 0f;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;

        GameManager = GameObject.Find("GameManager");
        if (GameManager != null)
        {
            objectPooling = GameManager.GetComponent<ObjectPooling>();
        }
    }

    void Update()
    {
        LeadShots();
        Targetting();

        //Debugging Stuff
        playerSpeed = player.GetComponent<Rigidbody>().velocity.magnitude;
    }


    void Fire()
    {

        float interval = 1f / (fireRate / 60 /* seconds */);
        if (Time.time > timeSinceFired)
        {
            SpawnObject();
            timeSinceFired = Time.time + interval;
        }
    }
    void LeadShots()
    {
        Vector3 playerPredictedPosition = player.position + (player.GetComponent<Rigidbody>().velocity * (timeAhead / bulletSpeed));

        // Calculate direction to predicted position
        Vector3 predictedDirection = playerPredictedPosition - transform.position;

        // Rotate towards the predicted position
        Quaternion targetRotation = Quaternion.LookRotation(predictedDirection, player.transform.up);
        transform.rotation =  targetRotation;
    }

    void Targetting()
    {
        Vector3 rayDirection = transform.forward;
        float rayLength = maxShootRange;

        float distance = (player.position - transform.position).magnitude;

        //For debugging
        distanceFromTarget = distance;

        // Create a layer mask that only includes the "Bullet" layer.
        int layerMask = 1 << LayerMask.NameToLayer("Bullet");

        // If player is Stationary
        if (Physics.Raycast(transform.position, rayDirection, out RaycastHit hit, rayLength, ~layerMask))
        {
            if (hit.collider.CompareTag("Player"))
            {
                if(minShootRange < distance && distance < maxShootRange)
                {
                    Fire();
                }
            }   

        }
        else
        {
            // If player is moving
            float playerSpeed = player.GetComponent<Rigidbody>().velocity.magnitude;
            if (lowerPlayerSpeed < playerSpeed && playerSpeed < upperPlayerSpeed)
            {
                Fire();
            }
        }


        Debug.DrawRay(transform.position, rayLength * rayDirection);
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
