using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KingOfTheHill : MonoBehaviour
{
    public GameObject countdownTimer;
    public GameObject boundaryVis;
    private CountdownTimer timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = countdownTimer.GetComponent<CountdownTimer>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            countdownTimer.SetActive(true);
            timer.canTick=true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        timer.canTick=false;
    }
    private void OnTriggerStay(Collider other)
    {

    }

}
