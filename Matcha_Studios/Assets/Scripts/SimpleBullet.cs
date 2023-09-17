using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleBullet : MonoBehaviour
{
    public float speed = 5.0f;
    Collider coll;

    private void Start()
    {
        //Vector3.right is X axis.
        //rotate the X axis 90 degrees to make it look like bullet.
        transform.Rotate(Vector3.right, 90.0f);
        coll = GetComponent<Collider>();
    }

    private void Update()
    {
        //transform.up is the Y axis.
        //then move the the bullet towards the target in Y direction each update.
        //transform.position += transform.up * speed * Time.deltaTime;

        //when touch an object, it disappears.
        //RaycastHit hit;
        //if (Physics.Raycast(transform.position, transform.up, out hit, 0.1f))
        //{
        //    if (hit.collider.CompareTag("Player") || hit.collider.CompareTag("AI") || hit.collider.CompareTag("Environment"))
        //    {
        //        //delete the bullet.
        //        Destroy(gameObject);
        //    }
        //}
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            //delete the bullet.
            Destroy(gameObject);

        }
    }

    //TODO:
    //Make object pooling.

}
