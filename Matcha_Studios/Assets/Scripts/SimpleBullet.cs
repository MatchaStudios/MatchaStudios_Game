using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    public float speed = 5.0f;
    public string team = "No Team";
    public float damage = 0f;
    public GameObject objectSpawnedFrom;
    Collider coll;

    private void Start()
    {
        //Vector3.right is X axis.
        //rotate the X axis 90 degrees to make it look like bullet.
        transform.Rotate(Vector3.right, 90.0f);
        coll = GetComponent<Collider>();
        //ownerName = gameObject.tag;
    }

    private void Update()
    {
        //transform.up is the Y axis.
        //then move the the bullet towards the target in Y direction each update.
        //transform.position += transform.up * speed * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == objectSpawnedFrom)
        {
            // Don't delete if it belongs to owner. 
        }
        else
        {
            // This might mean enemies bullets will phase through enemies. 
            if (other.gameObject.tag == "AI")
            {
                Destroy(gameObject);
            }
            if (other.gameObject.tag == "Player")
            {
                //delete the bullet.
                Destroy(gameObject);
            }
            if (other.gameObject.tag == "Environment")
            {
                //delete the bullet.
                Destroy(gameObject);
            }
        }
    }

    //TODO:
    //Make object pooling.

}
