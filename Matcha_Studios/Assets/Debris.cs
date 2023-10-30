using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Debris : MonoBehaviour
{
    public SubMissionOne subMission;
    public AudioClip clip;

    private void Start()
    {
        subMission = GameObject.Find("Sub Mission 1").GetComponent<SubMissionOne>();
    }

    private void Update()
    {
        clip = subMission.audioSource.clip;
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            subMission.DebrisCount += 1;
            if (subMission.DebrisCount == 1)
            {
                subMission.audioSource.clip = subMission.DamnPirates;
            }
            else if (subMission.DebrisCount == 2)
            {
                subMission.audioSource.clip = subMission.AwwHellIThoughtTheyDied;
            }
            else if (subMission.DebrisCount == 3)
            {
                subMission.audioSource.clip = subMission.TheseDamnPirates;
            }
            else if (subMission.DebrisCount == 4)
            {
                subMission.audioSource.clip = subMission.WhoaTheresMore;

                // CURRENTLY ENEMY COUNT NOT WORKING!!!!!!!!!!!!!
                if(subMission.EnemyCount >= 2)
                {
                    subMission.audioSource.clip = subMission.ThosePartsCouldSaveUs;
                }
            }
            else
            {
                //ending
                subMission.audioSource.clip = subMission.HeyThanksALot;
            }
            subMission.audioSource.Play();
            gameObject.SetActive(false);
        }
    }
}
