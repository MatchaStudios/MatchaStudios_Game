using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField]
    float damage;
    [SerializeField]
    float lifetime;
    [SerializeField]
    float speed;
    [SerializeField]
    LayerMask collisionMask;
    [SerializeField]
    float width;
    new Rigidbody rigidbody;
    Vector3 lastPosition;
    float startTime;

    public void Fire()
    {
        rigidbody = GetComponent<Rigidbody>();
        startTime = Time.time;
        rigidbody.AddRelativeForce(new Vector3(0, 0, speed), ForceMode.VelocityChange);
        lastPosition = rigidbody.position;
    }

    void FixedUpdate()
    {
        if (Time.time > startTime + lifetime)
        {
            Destroy(gameObject);
            return;
        }

        var diff = rigidbody.position - lastPosition;
        lastPosition = rigidbody.position;

        Ray ray = new Ray(lastPosition, diff.normalized);
        RaycastHit hit;

        if (Physics.SphereCast(ray, width, out hit, diff.magnitude, collisionMask.value))
        {
            //Plane other = hit.collider.GetComponent<Plane>();
            //DO DAMAGE FIND LIKE ABOVE
        }
    }
}
