using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AcceptMission : MonoBehaviour
{
    public Action acceptedMission;
    public Action rejectMission;
    public InputActionReference acceptKey;
    public InputActionReference rejectKey;
    public SideMission GM;

    public Transform PlayerTransform;


    private void Start()
    {
        PlayerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        GM = GameObject.FindGameObjectWithTag("GameController").GetComponent<SideMission>();
        gameObject.SetActive(true);
    }

    void OnEnable()
    {
        acceptKey.action.Enable();
        acceptKey.action.performed += ctx => AcceptM();

        rejectKey.action.Enable();
        rejectKey.action.performed += ctx => RejectM();
    }

    void OnDisable()
    {
        acceptKey.action.Disable();
        acceptKey.action.performed -= ctx => AcceptM();

        rejectKey.action.Disable();
        rejectKey.action.performed -= ctx => RejectM();
    }

    void AcceptM()
    {
        float distanceToSpawnFromPlayer = 70;
        Vector3 playerBackDirection = - PlayerTransform.forward;
        
        GM.SubMissionArray[0].SetActive(true);
        GM.SubMissionArray[0].transform.position = PlayerTransform.position + distanceToSpawnFromPlayer * playerBackDirection;
        gameObject.SetActive(false);
        acceptedMission?.Invoke();
    }
    void RejectM()
    {
        gameObject.SetActive(false);
        rejectMission?.Invoke();
    }

}
