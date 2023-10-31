using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidSpawner : MonoBehaviour
{
    public GameObject[] asteroidObjects;

    public int amountAsteroidsToSpawn = 10;

    public float minRandomSpawn = -300;
    public float maxRandomSpawn = 300;
    public Vector3 minScale = new Vector3(0.5f, 0.5f, 0.5f); // Minimum scale
    public Vector3 maxScale = new Vector3(5.0f, 5.0f, 5.0f);
    public PatternType spawnPattern;
    public float radius = 250.0f; // Radius of the arc
    public float arcAngle = 80.0f; // Angle of the arc in degrees
    public float positionVariance = 70f; // Maximum variance in position

    public enum PatternType
    {
        SCATTER,
        ARC
    }
    int x, y, z;

    private void Start()
    {
        SpawnAsteroid(spawnPattern);
    }

    void SpawnAsteroid(PatternType pattern)
    {
        if (pattern == PatternType.SCATTER)
        {
            for (int i = 0; i < amountAsteroidsToSpawn; i++)
            {
                float _foo = Random.Range(minScale.x, maxScale.x);
                Vector3 randomScale = new Vector3(_foo, _foo, _foo);

                float randomX = Random.Range(minRandomSpawn, maxRandomSpawn);
                float randomY = Random.Range(minRandomSpawn, maxRandomSpawn);
                float randomZ = Random.Range(minRandomSpawn, maxRandomSpawn);

                float randomXRotation = Random.Range(0.0f, 360.0f);
                float randomYRotation = Random.Range(0.0f, 360.0f);
                float randomZRotation = Random.Range(0.0f, 360.0f);


                Vector3 randomSpawnPoint =
                    new Vector3(transform.position.x + randomX, transform.position.y + randomY, transform.position.z + randomZ);

                GameObject tempObj = Instantiate(asteroidObjects[0], randomSpawnPoint, Quaternion.identity);
                tempObj.transform.parent = this.transform;
                tempObj.transform.localScale = randomScale;
                tempObj.transform.rotation = Quaternion.Euler(randomXRotation, randomYRotation, randomZRotation);
            }
        }
        if (pattern == PatternType.ARC)
        {
            for (int i = 0; i < amountAsteroidsToSpawn; i++)
            {
                float _foo = Random.Range(minScale.x, maxScale.x);
                Vector3 randomScale = new Vector3(_foo, _foo, _foo);



                float randomXRotation = Random.Range(0.0f, 360.0f);
                float randomYRotation = Random.Range(0.0f, 360.0f);
                float randomZRotation = Random.Range(0.0f, 360.0f);

                float angle = i * (arcAngle / (amountAsteroidsToSpawn - 1)) - arcAngle / 2.0f; // Calculate the angle within the wider arc


                // Calculate the variance in position for each object
                float varianceX = Random.Range(-positionVariance, positionVariance);
                float varianceY = Random.Range(-positionVariance, positionVariance);
                float varianceZ = Random.Range(-positionVariance, positionVariance);

                float x = transform.position.x+ radius * Mathf.Cos(Mathf.Deg2Rad * angle) + varianceX;
                float y = transform.position.y+varianceY; // Adjust the y-axis position variance if needed
                float z = transform.position.z+radius * Mathf.Sin(Mathf.Deg2Rad * angle) + varianceZ;

                Vector3 position = new Vector3(x, y, z);

                GameObject tempObj = Instantiate(asteroidObjects[0], position, Quaternion.identity);
                tempObj.transform.parent = this.transform;
                tempObj.transform.localScale = randomScale;
                tempObj.transform.rotation = Quaternion.Euler(randomXRotation, randomYRotation, randomZRotation);
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(transform.position, new Vector3(maxRandomSpawn * 2, maxRandomSpawn * 2, maxRandomSpawn * 2));
    }


}
