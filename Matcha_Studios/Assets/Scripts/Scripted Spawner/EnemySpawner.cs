using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

//Only for GameManager GameObject
public class EnemySpawner : Timer
{
    [Header("=== Keys to Spawn Enemies ===")]
    public GameObject AIEnemyNormal;
    public GameObject AIEnemyOrbital;
    public GameObject AIEnemyCarrier;

    // Drag your desired input action to this field in the inspector.
    public InputActionReference spawnKeyJ;
    public InputActionReference spawnKeyK;
    public InputActionReference spawnKeyL;

    [Header("=== Offset spawn positions ===")]
    public GameObject player; // get the player.
    public float spawnDistanceNormal = 25f; // Adjust the distance from the player
    public float spawnDistanceOrbital = 30f; // Adjust the distance from the player
    public float spawnDistanceCarrier = 40f; // Adjust the distance from the player

    [Header("=== List Of All Enemies ===")]
    public List<GameObject> TotalEnemies = new List<GameObject>();

    [Header("=== Object Pooling ===")]
    ObjectPooling objectPooling;

    //very scuffed adaptive audio fields
    private bool firedFirst = false;
    public MusicManager musicManager;
    private int timesFired;
    // end of adaptive audio fields
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        objectPooling = gameObject.GetComponent<ObjectPooling>();
    }
    
    void Update()
    {
        /*
        * Does not account for any other scripted events.
        */

        if (TotalEnemies.Count <= 0)
        {
            UpdateTimer();
        }
        if (time <= 0)
        {
            ResetTimer();
            //M3 stuff...
            //enemy position spawns further from expected spawn point.
            //enemy object, while mesh is disabled zooms forward to show trail.
            //after zooming forward, mesh enables.

            //M2
            //Enemy spawns near player

            SpawnObject1();
            SpawnObject1();
            SpawnObject2();
            SpawnObject3();

            //Scuffed adaptive audio 
            if(!firedFirst)
            {
                firedFirst=true;
                musicManager.FireLayer3();
                
            }
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("AI");
            foreach (GameObject enemy in enemies)
            {
                TotalEnemies.Add(enemy);
            }
        }

        foreach (GameObject enemy in TotalEnemies.ToList())
        {
            if(enemy.activeInHierarchy == false)
            {
                TotalEnemies.Remove(enemy);
            }
        }
    }

    void OnEnable()
    {
        spawnKeyJ.action.Enable();
        spawnKeyJ.action.performed += ctx => SpawnObject1();

        spawnKeyK.action.Enable();
        spawnKeyK.action.performed += ctx => SpawnObject2();

        spawnKeyL.action.Enable();
        spawnKeyL.action.performed += ctx => SpawnObject3();
    }

    void OnDisable()
    {
        spawnKeyJ.action.Disable();
        spawnKeyJ.action.performed -= ctx => SpawnObject1();

        spawnKeyK.action.Disable();
        spawnKeyK.action.performed -= ctx => SpawnObject2();

        spawnKeyL.action.Disable();
        spawnKeyL.action.performed -= ctx => SpawnObject3();
    }

    void SpawnObject1()
    {
        Vector3 spawnPosition = player.transform.position + (transform.forward * spawnDistanceNormal);
        Instantiate(AIEnemyNormal, spawnPosition, Quaternion.identity);
        //GameObject spawnedObject = objectPooling.GetObjectFromPool(AIEnemyNormal.name);
        //spawnedObject.transform.position = spawnPosition;
    }
    void SpawnObject2()
    {
        Vector3 spawnPosition = player.transform.position + (transform.forward * spawnDistanceOrbital);
        Instantiate(AIEnemyOrbital, spawnPosition, Quaternion.identity);
        //GameObject spawnedObject = objectPooling.GetObjectFromPool(AIEnemyOrbital.name);
        //spawnedObject.transform.position = spawnPosition;
    }
    void SpawnObject3()
    {
        Vector3 spawnPosition = player.transform.position + (transform.forward * spawnDistanceCarrier);
        Instantiate(AIEnemyCarrier, spawnPosition, Quaternion.identity);
        //GameObject spawnedObject = objectPooling.GetObjectFromPool(AIEnemyCarrier.name);
        //spawnedObject.transform.position = spawnPosition;
    }

    public void SpawnWave()
    {
        //Vector3 carrierSpawnPosition = player.transform.position + (transform.forward * spawnDistanceCarrier);
        for (int i = 0; i < 1; i++)
        {
            SpawnObject3();
            //Instantiate(AIEnemyCarrier, carrierSpawnPosition, Quaternion.identity);
        }
        //Vector3 orbitalSpawnPosition = player.transform.position + (transform.forward * spawnDistanceOrbital);
        for (int i = 0; i < 2; i++)
        {
            SpawnObject2();
            //Instantiate(AIEnemyOrbital, orbitalSpawnPosition, Quaternion.identity);
        }
        //Vector3 normalSpawnPosition = player.transform.position + (transform.forward * spawnDistanceNormal);
        for (int i = 0; i < 3; i++)
        {
            SpawnObject1();
            //Instantiate(AIEnemyNormal, normalSpawnPosition, Quaternion.identity);
        }

    }
}
