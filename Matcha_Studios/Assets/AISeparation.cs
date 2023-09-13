using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISeparation : MonoBehaviour
{
    public GameObject[] AI;
    public GameObject[] Environment;
    public float SpaceBetween = 2f;

    void Start()
    {
        AI = GameObject.FindGameObjectsWithTag("AI");
        Environment = GameObject.FindGameObjectsWithTag("Environment");
    }

    void Update()
    {
        foreach (GameObject go in AI)
        {
            //if go is not this game object.
            if (go != gameObject)
            {
                float distance = Vector3.Distance(go.transform.position, this.transform.position);
                if (distance <= SpaceBetween)
                {
                    m_Translation(go);
                }
            }
            foreach (GameObject envObject in Environment)
            {
                float distance = Vector3.Distance(go.transform.position, envObject.transform.position);
                if (distance <= SpaceBetween)
                {
                    m_Translation(go);
                }
            }
        }
    }

    void m_Translation(GameObject go)
    {
        Vector3 direction = transform.position - go.transform.position;
        transform.Translate(direction * Time.deltaTime);
    }


}
