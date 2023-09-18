using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int initHealth;
    public int curHealth;
    public int maxHealth;

    void Start()
    {
        initHealth  = maxHealth;
        curHealth   = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnTriggerEnter(Collider other)
    {
        // if hit by player health goes down by the bullet damage
        if(other.gameObject.tag == "PlayerBullet")
        {
            
        }
    }
}
