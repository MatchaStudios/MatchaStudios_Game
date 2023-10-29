using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[RequireComponent((typeof(Spaceship)))]
[RequireComponent((typeof(SpaceshipShooting)))]
public class ShipEnergy : MonoBehaviour
{
    float regenTimer;
    public float energyRegenSpeed = 0.5f;
    bool pauseRegen;
    public float energy = 1f;
    public float CurrentEnergy
    {
        get { return energy; }
        set { }
    }
    private float maxEnergy = 1f;
    public float MaxEnergy
    {
        get { return maxEnergy; }
    }
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        regenTimer -= Time.deltaTime;
        if (regenTimer <= 0f)
        {
            energy +=  energyRegenSpeed * Time.deltaTime;
            energy = Mathf.Clamp(energy,0,maxEnergy);
        }
        // Debug.Log("Energy at " + energy.ToString());
        // energy -= 0.25f * Time.deltaTime;
    }

    public void ResetEnergyTimer()
    {
        regenTimer = 1.5f;
    }
}
