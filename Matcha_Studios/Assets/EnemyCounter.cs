using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCounter : MonoBehaviour
{
    HealthComponent HC;
    SubMissionOne SubMission;
    public int toAdd = 1;
    // Start is called before the first frame update
    void Start()
    {
        HC = GetComponent<HealthComponent>();
    }

    // Update is called once per frame
    void Update()
    {
        if (HC.isAlive == false || HC.curHealth <= 0)
        {
            SubMission.EnemyCount += 1;
        }
    }
}
