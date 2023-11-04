using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SubMissionOne : MonoBehaviour
{
    //Scuffed audio adaptive fields
    public MusicManager musicManager;
    private bool firedMusic = false;
    public Action completedSubMissionOne;
    [SerializeField]
    public AudioSource audioSource;

    public AudioClip
        StationStuck, //when accepted mission
        DamnPirates, //Debris count 1
        AwwHellIThoughtTheyDied, //Debris count 2
        TheseDamnPirates, //Debris count 3
        WhoaTheresMore, // Debris count 4
        ThosePartsCouldSaveUs, //Debris count 4 and after last enemy died.
        HeyThanksALot; //Debris count 5


    public GameObject ScriptedEnemySpawner1, ScriptedEnemySpawner2;
    public int EnemyCount = 0;

    public int DebrisCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = StationStuck;
        audioSource.Play();
    }

    // Update is called once per frame
    void Update()
    {
        //// ScriptedEnemySpawner1
        //if (ScriptedEnemySpawner1.activeInHierarchy)
        //{
        //    for (int i = 0; i < ScriptedEnemySpawner1.transform.childCount; i++)
        //    {
        //        Transform child = ScriptedEnemySpawner1.transform.GetChild(i);
        //        // Do something with the child
        //        Debug.Log("Child " + i + ": " + child.name);

        //        if (child.GetComponent<HealthComponent>().curHealth == 0)
        //        {
        //            EnemyCount++;
        //        }
        //    }
        //}
        //// ScriptedEnemySpawner2
        //if (ScriptedEnemySpawner2.activeInHierarchy)
        //{
        //    for (int i = 0; i < ScriptedEnemySpawner2.transform.childCount; i++)
        //    {
        //        Transform child = ScriptedEnemySpawner2.transform.GetChild(i);
        //        // Do something with the child
        //        Debug.Log("Child " + i + ": " + child.name);

        //        if (child.GetComponent<HealthComponent>().curHealth == 0)
        //        {
        //            EnemyCount++;
        //        }
        //    }
        //}

        if (DebrisCount == 2)
        {
            //enemy spawn
            ScriptedEnemySpawner1.SetActive(true);



        }
        if (DebrisCount == 4)
        {
            //enemy spawn
            ScriptedEnemySpawner2.SetActive(true);
        }
        if (DebrisCount >= 5)
        {
            completedSubMissionOne?.Invoke();
            ScriptedEnemySpawner1.SetActive(false);
            ScriptedEnemySpawner2.SetActive(false);
            if (!firedMusic)
            {
                musicManager.FireLayer5();
                firedMusic = true;
            }

            //TODO:
            // ADD REWARD TO PLAYER HERE
            // ---
            // Give better fire rate of weapon or health than Main Mission to 
            // encourage player to do side missions.
        }
    }
}
