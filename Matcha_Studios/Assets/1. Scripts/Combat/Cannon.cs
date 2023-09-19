using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
    [Header("Weapons")]
    [SerializeField]
    [Tooltip("Firing rate in Rounds Per Minute")]
    float cannonFireRate;
    [SerializeField]
    float cannonSpread;
    [SerializeField]
    Transform cannonSpawnPoint;
    [SerializeField]
    GameObject bulletPrefab;
    List<float> missileReloadTimers;
    float missileDebounceTimer;
    Vector3 missileLockDirection;

    bool cannonFiring;
    float cannonDebounceTimer;
    float cannonFiringTimer;

    public bool Dead { get; private set; }

    void Start()
    {

    }


    public void SetCannonInput(bool input)
    {
        if (Dead) return;
        cannonFiring = input;
    }

    public void ApplyDamage(float damage)
    {

    }


    void UpdateWeapons(float dt)
    {
        UpdateWeaponCooldown(dt);

        UpdateCannon(dt);
    }

    void UpdateWeaponCooldown(float dt)
    {
        missileDebounceTimer = Mathf.Max(0, missileDebounceTimer - dt);
        cannonDebounceTimer = Mathf.Max(0, cannonDebounceTimer - dt);
        cannonFiringTimer = Mathf.Max(0, cannonFiringTimer - dt);
    }



    void UpdateCannon(float dt)
    {
        if (cannonFiring && cannonFiringTimer == 0)
        {
            cannonFiringTimer = 60f / cannonFireRate;

            var spread = Random.insideUnitCircle * cannonSpread;

            var bulletGO = Instantiate(bulletPrefab, cannonSpawnPoint.position, cannonSpawnPoint.rotation * Quaternion.Euler(spread.x, spread.y, 0));
            var bullet = bulletGO.GetComponent<Bullet>();
            bullet.Fire();
        }
    }

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        //update weapon state
        UpdateWeapons(dt);
    }
}
