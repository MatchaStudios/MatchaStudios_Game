using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class KingOfTheHill : MonoBehaviour
{
    public Action playerEntered;
    public GameObject countdownTimer;
    public GameObject boundaryVis;
    public EnemySpawner enemySpawner;
    private CountdownTimer timer;
    public TypewriterEffect writer;

    public OnMissionStart missionStart;

    public Text objectiveText1;
    public Text objectiveText2;


    // Start is called before the first frame update
    void Start()
    {
        timer = countdownTimer.GetComponent<CountdownTimer>();
        boundaryVis.SetActive(false);

        missionStart = objectiveText1.GetComponent<OnMissionStart>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void BoundaryOff()
    {
        boundaryVis.SetActive(false);
    }

    private void OnEnable()
    {
        writer.endedObjective += BoundaryOff;
    }
    private void OnDisable()
    {
        writer.endedObjective -= BoundaryOff;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            objectiveText1.gameObject.SetActive(false);
            Debug.Log("PLAYER ENTERED");
            boundaryVis.SetActive(true);
            playerEntered?.Invoke();
            enemySpawner.SpawnWave();
            countdownTimer.SetActive(true);
            timer.canTick = true;
            objectiveText2.gameObject.SetActive(true);
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