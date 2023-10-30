using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class KingOfTheHill : MonoBehaviour
{
    public Action playerEntered;
    public GameObject countdownTimer;
    public GameObject boundaryVis;
    public EnemySpawner enemySpawner;
    private CountdownTimer timer;
    public TypewriterEffect writer;

    // Start is called before the first frame update
    void Start()
    {
        timer = countdownTimer.GetComponent<CountdownTimer>();
        boundaryVis.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void BoundaryOff () {
        boundaryVis.SetActive(false);
    }

    private void OnEnable() {
        writer.endedObjective+=BoundaryOff;
    }
    private void OnDisable() {
        writer.endedObjective-=BoundaryOff;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            Debug.Log("PLAYER ENTERED");
            boundaryVis.SetActive(true);
            playerEntered?.Invoke();
            enemySpawner.SpawnWave();
            countdownTimer.SetActive(true);
            timer.canTick = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            boundaryVis.SetActive(false);
            timer.canTick = false;
        }
    }
    private void OnTriggerStay(Collider other)
    {

    }

}
