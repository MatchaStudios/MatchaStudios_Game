using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISeparation : MonoBehaviour
{
    public GameObject[] AI;
    public GameObject[] Environment;
    public float SpaceBetween = 2f;
    public Rigidbody rb;
    public float repelForce = 1f;

    void Start()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");
        Environment = GameObject.FindGameObjectsWithTag("Environment");
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");
        Environment = GameObject.FindGameObjectsWithTag("Environment");
        foreach (GameObject go in AI)
        {
            //if go is not this game object.
            if (go != gameObject)
            {
                if(go)
                {
                    float distance = Vector3.Distance(go.transform.position, this.transform.position);

                    if (distance <= SpaceBetween)
                    {
                        //m_Translation(go);
                        Vector3 direction = (go.transform.position - transform.position).normalized;
                        rb.AddForce(- repelForce * direction, ForceMode.Impulse);
                    }
                }
            }
            //foreach (GameObject envObject in Environment)
            //{
            //    float distance = Vector3.Distance(go.transform.position, envObject.transform.position);
            //    if (distance <= SpaceBetween)
            //    {
            //        m_Translation(go);
            //    }
            //}
        }
    }

    //void m_Translation(GameObject go)
    //{
    //    Vector3 direction = transform.position - go.transform.position;
    //    transform.Translate(direction * Time.deltaTime);
    //}


}
