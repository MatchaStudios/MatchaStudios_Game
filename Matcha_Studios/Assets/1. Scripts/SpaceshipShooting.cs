using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent((typeof(ShipEnergy)))]
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
    private float hardpointRange = 10000f;
    [SerializeField] private ParticleSystem laserHitParticles;
    private bool targetInRange = false;

    [Header("=== Laser Settings ===")]
    [SerializeField]
    private LineRenderer[] lasers;

    [SerializeField]
    private float miningPower = 1f;
    [SerializeField]
    private float laserHeatThreshold = 0f;
    [SerializeField]
    private float laserHeatRate = 0.25f;
    [SerializeField]
    private float laserCoolRate = 0.5f;
    [SerializeField]
    private float timeBetweenDamageApplication = 0.0f;
    private float currentTimeBetweenDamageApplication;
    [SerializeField]
    private float laserDamage = 1f;

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
    /// <summary>
    /// Start is called on the frame when a script is enabled just before
    /// any of the Update methods is called the first time.
    /// </summary>
    private void Start()
    {
       
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
            foreach (var laser in lasers)
            {
                laser.gameObject.SetActive(false);
            }

            CoolLaser();
        }
    }
    void ApplyDamage(HealthComponent healthComponent)
    {
        currentTimeBetweenDamageApplication += Time.deltaTime;

        //if (currentTimeBetweenDamageApplication > timeBetweenDamageApplication)
        //{
            currentTimeBetweenDamageApplication = 0f;
            healthComponent.TakeDamage(laserDamage);
            Debug.Log("doing damage");
       // }
    }
    void FireLaser()
    {
        RaycastHit hitInfo;
        SoundManager.Instance.PlaySFX("Laser");
        if (TargetInfo.IsTargetInRange(hardpointMiddle.transform.position, cam.transform.forward, out hitInfo, hardpointRange, shootableMask))
        {
            Debug.Log("In range");
            if (hitInfo.collider.GetComponentInParent<HealthComponent>()) 
            {
                Debug.Log("can damage");
                ApplyDamage(hitInfo.collider.GetComponentInParent<HealthComponent>());
            }
            Instantiate(laserHitParticles, hitInfo.point, Quaternion.LookRotation(hitInfo.normal));

            foreach (var laser in lasers)
            {
                Vector3 localHitPosition = laser.transform.InverseTransformPoint(hitInfo.point);
                laser.gameObject.SetActive(true);
                laser.SetPosition(1, localHitPosition);
            }
        }
        else
        {
            foreach (var laser in lasers)
            {
                laser.gameObject.SetActive(true);
                laser.SetPosition(1, new Vector3(0, 0, hardpointRange));
            }
        }
        GetComponent<ShipEnergy>().ResetEnergyTimer();
        HeatLaser();
    }

    void HeatLaser()
    {
        GetComponent<ShipEnergy>().energy -= laserHeatRate * Time.deltaTime;
        if (firing && GetComponent<ShipEnergy>().energy < GetComponent<ShipEnergy>().MaxEnergy)
        {
            //GetComponent<ShipEnergy>().energy -= laserHeatRate * Time.deltaTime;
            Debug.Log("Energy at " + GetComponent<ShipEnergy>().energy.ToString());

            if (currentLaserHeat >= GetComponent<ShipEnergy>().CurrentEnergy)
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
            if (currentLaserHeat / GetComponent<ShipEnergy>().CurrentEnergy <= 0.5f)
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
