using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    public float speed = 5.0f;
    public string team = "No Team";
    public float damage = 0f;

    // ObjectSpawnFrom should have been registered when instantiated in Shoot.cs.
    public GameObject objectSpawnedFrom;
    Collider coll;
    public float bulletLifetime = 10f;
    Timer lifeTimer;

    private void Start()
    {
        coll = GetComponent<Collider>();
        lifeTimer = gameObject.AddComponent<Timer>();
        lifeTimer.timerSet = bulletLifetime;
        //ownerName = gameObject.tag;
    }

    public void Init()
    {
        if (lifeTimer)
            lifeTimer.ResetTimer();
    }

    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        if (lifeTimer == null)
            return;

        if (lifeTimer.GetTimerStopped() == false)
        {
            lifeTimer.UpdateTimer();
        }
        else
        {
            DestroyBullet();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == objectSpawnedFrom)
        {
            // Don't delete if it belongs to owner. 
        }
        else
        {
            // Collision tags
            if (other.gameObject.tag == "AI")
            {
                gameObject.SetActive(false);
            }
            if (other.gameObject.tag == "Player")
            {
                gameObject.SetActive(false);
            }
            if (other.gameObject.tag == "Environment")
            {
                gameObject.SetActive(false);
            }
        }
    }
}
