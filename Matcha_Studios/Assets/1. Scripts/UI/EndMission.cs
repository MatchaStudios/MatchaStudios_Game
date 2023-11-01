using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EndMission : MonoBehaviour
{
    public GameObject endScreen;
    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            endScreen.SetActive(true);
        }
    }
    
    // Update is called once per frame
    void Update()
    {

    }
}
