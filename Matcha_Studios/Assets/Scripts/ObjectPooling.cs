using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    //create an array of gameobjects.
    public GameObject[] prefabs;
    //create an array of poolsize for each gameobject in sequence.
    public int[] poolSize;

    //List of gameobjects to pool.
    private List<GameObject> objectPool = new List<GameObject>();

    void Start()
    {
        InitializePool();
    }

    void InitializePool()
    {
        //get the length of gameobject array
        int gameObjectArrayLength = prefabs.Length;

        //get the length of poolsize array
        int poolSizeArrayLength = poolSize.Length;

        // to access each element of poolsize array
        int i = 0;

        for (int j = 0; j < gameObjectArrayLength; j++)
        {
            for(int p = 0; p < poolSize[i]; p++)
            {
                GameObject obj = Instantiate(prefabs[j]);

                //Force all cloned object to have same name as prefab
                obj.name = prefabs[j].name;

                obj.SetActive(false);
                objectPool.Add(obj);
            }
            i++;
        }
    }

    public GameObject GetObjectFromPool(string type)
    {
        foreach (GameObject obj in objectPool)
        {
            // If active, and matches object type by name
            // We forced object name to match prefab in instantiation
            Debug.Log("Finding Object");
            if (obj.activeInHierarchy == false && obj.name == type)
            {
                //obj.transform.position = position;
                //obj.transform.rotation = rotation;
                obj.SetActive(true);
                return obj;
            }
        }

        // If all objects are in use, you can choose to grow the pool by instantiating more objects here.
        return null;
    }
}
