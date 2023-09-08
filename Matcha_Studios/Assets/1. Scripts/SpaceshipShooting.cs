using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpaceshipShooting : MonoBehaviour
{
    [Header("=== Spaceship Settings ===")]
    [SerializeField] private Spaceship spaceship;

    [Header("=== Hardpoint Settings ===")]
    [SerializeField]
    private Transform[] hardpoints;
    [SerializeField] private Transform hardpointMiddle;
    [SerializeField]
    private LayerMask shootableMask;
    [SerializeField]
    private float hardpointRange = 100f;

    private bool targetInRange = false;

    [Header("=== Laser Settings ===")]
    [SerializeField]
    private LineRenderer[] lasers;
    [SerializeField]
    private ParticleSystem laserHitParticles;
    [SerializeField]
    private float miningPower = 1f;
    [SerializeField]
    private float laserHeatThreshold = 2f;
    [SerializeField]
    private float laserHeatRate = 0.25f;
    [SerializeField]
    private float laserCoolRate = 0.5f;

    private float currentLaserHeat = 0f;
    private bool overHeated = false;

    private bool firing;

    private Camera cam;

    public float CurrentLaserHeat
    {
        get { return currentLaserHeat; }
    }

    public float LaserHeatThreshold
    {
        get { return laserHeatThreshold; }
    }

    private void Awake()
    {
        cam = Camera.main;
        spaceship = GetComponent<Spaceship>();
    }

    private void Update()
    {
            HandleLaserFiring();

    }

    private void HandleLaserFiring()
    {
        if (firing && !overHeated)
        {
            FireLaser();
        }
        else
        {
            foreach(var laser in lasers)
            {
                laser.gameObject.SetActive(false);
            }

            CoolLaser();
        }
    }

    void FireLaser()
    {
        RaycastHit hitInfo;

        if(TargetInfo.IsTargetInRange(hardpointMiddle.transform.position, cam.transform.forward, out hitInfo, hardpointRange, shootableMask))
        {
           // Instantiate(laserHitParticles, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

            foreach (var laser in lasers)
            {
                Vector3 localHitPosition = laser.transform.InverseTransformPoint(hitInfo.point);
                laser.gameObject.SetActive(true);
                laser.SetPosition(1, localHitPosition);
            }
        }
        else
        {
            foreach(var laser in lasers)
            {
                laser.gameObject.SetActive(true);
                laser.SetPosition(1, new Vector3(0, 0, hardpointRange));
            }
        }

        HeatLaser();
    }

    void HeatLaser()
    {
        if (firing && currentLaserHeat < laserHeatThreshold)
        {
            currentLaserHeat += laserHeatRate * Time.deltaTime;

            if (currentLaserHeat >= laserHeatThreshold)
            {
                overHeated = true;
                firing = false;
            }
        }
        
    }

    void CoolLaser()
    {
        if (overHeated)
        {
            if (currentLaserHeat / laserHeatThreshold <= 0.5f)
            {
                overHeated = false;
            }
        }

        if (currentLaserHeat > 0f)
        {
            currentLaserHeat -= laserCoolRate * Time.deltaTime;
        }
    }


    #region Input
    public void OnFire(InputAction.CallbackContext context)
    {
        firing = context.performed;
    }
    #endregion
}
