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
    Timer explodeTimer;

    private void Start()
    {
        coll = GetComponent<Collider>();
        // explodeTimer = gameObject.AddComponent<Timer>();
        //explodeTimer.timerSet = bulletLifetime;
        //ownerName = gameObject.tag;
    }

    public void Init()
    {
        if (explodeTimer)
            explodeTimer.ResetTimer();
    }

    void DestroyBullet()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        // Todo: fix this.
        // its not setting properly.
        if (explodeTimer.GetTimerStopped() == false)
        {
            explodeTimer.UpdateTimer();
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
