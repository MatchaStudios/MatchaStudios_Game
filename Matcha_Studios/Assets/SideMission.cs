using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SideMission : MonoBehaviour
{
    public GameObject[] SubMissionArray;
    public GameObject[] SubMissionUIArray;
    public Transform PlayerTransform;
    public Transform MainMissionStation;
    public float distance, halfwayThere;
    public bool test = false;

    //check player distance
    //midway then ui spawns up

    private void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        MainMissionStation = GameObject.Find("Main Mission 1").transform;
        distance = Vector3.Distance(MainMissionStation.transform.position, PlayerTransform.position);
        halfwayThere = distance / 2;
    }
    private void Update()
    {
        distance = Vector3.Distance(MainMissionStation.transform.position, PlayerTransform.position);

        if (Vector3.Distance(MainMissionStation.transform.position, PlayerTransform.position) < halfwayThere && test == false)
        {
            test = true;
            SubMissionUIArray[0].SetActive(true);
        }
    }
}
