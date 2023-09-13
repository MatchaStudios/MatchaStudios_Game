using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidance : MonoBehaviour
{
    [Range(0, 1)]
    public float moveSpeed = 0.1f;
    [Range(0, 1)]
    public float avoidSpeedPercentage = 0.5f;

    public float avoidSpeed = 10f;
    public float stoppingDistance = 2.0f;

    public Pathfind pathfind;

    // Start is called before the first frame update
    void Start()
    {
        //pathfind = GetComponent<Pathfind>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //void AvoidCollision()
    //{
    //    RaycastHit hit;
    //    if (Physics.Raycast(transform.position, transform.forward, out hit, 5.0f))
    //    {
    //        if (hit.collider.CompareTag("Environment"))
    //        {
    //            Vector3 ObstacleNormal = hit.normal;
    //            Vector3 direction = (pathfind.player.transform.position - transform.position).normalized;
    //            Vector3 dirToGo = Vector3.Cross(ObstacleNormal, direction);

    //            transform.Translate(avoidSpeed * dirToGo * Time.deltaTime);

    //            Debug.DrawRay(transform.position, 10 * dirToGo, Color.red);
    //        }
    //    }
    //}
}
