using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidGenerator : MonoBehaviour
{
    public float spawnRange;
    public float amountToSpawn;
    private Vector3 spawnPoint;
    public GameObject asteroid;
    public float startSafeRange;
    public Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f); // Minimum scale
    public Vector3 maxScale = new Vector3(2.0f, 2.0f, 2.0f);
    private List<GameObject> objectsToPlace = new List<GameObject>();
    public PatternType spawnPattern;

    public enum PatternType
    {
        SCATTER,
        ARC
    }
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            // Generate a random scale within the specified range
            Vector3 randomScale = new Vector3(
                Random.Range(minScale.x, maxScale.x),
                Random.Range(minScale.y, maxScale.y),
                Random.Range(minScale.z, maxScale.z)
            );
            PickSpawnPoint();

            //pick new spawn point if too close to player start
            while (Vector3.Distance(spawnPoint, Vector3.zero) < startSafeRange)
            {
                PickSpawnPoint();
            }

            objectsToPlace.Add(Instantiate(asteroid, spawnPoint, Quaternion.Euler(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f))));
            objectsToPlace[i].transform.parent = this.transform;
            objectsToPlace[i].transform.localScale = randomScale;
        }

        asteroid.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void PickSpawnPoint()
    {
        spawnPoint = new Vector3(
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f),
            Random.Range(-1f, 1f));

        if (spawnPoint.magnitude > 1)
        {
            spawnPoint.Normalize();
        }

        spawnPoint *= spawnRange;
    }
}

