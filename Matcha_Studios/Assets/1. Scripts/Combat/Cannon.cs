using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using System;

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
    public static Action energyUsed;

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
        if (cannonFiring && cannonFiringTimer == 0 && GetComponent<ShipEnergy>().energy>0)
        {
            GetComponent<ShipEnergy>().ResetEnergyTimer();
            GetComponent<ShipEnergy>().energy -= .25f * Time.deltaTime;
            energyUsed?.Invoke();
            cannonFiringTimer = 60f / cannonFireRate;

            var spread = UnityEngine.Random.insideUnitCircle * cannonSpread;

            var bulletGO = Instantiate(bulletPrefab, cannonSpawnPoint.position, cannonSpawnPoint.rotation * Quaternion.Euler(spread.x, spread.y, 0));
            var bullet = bulletGO.GetComponent<Bullet>();
            bullet.Fire();
            SoundManager.Instance.PlaySFX("Canon");
        }
    }

    void FixedUpdate()
    {
        float dt = Time.fixedDeltaTime;

        //update weapon state
        UpdateWeapons(dt);
    }

    public void OnFireCannon(InputAction.CallbackContext context)
    {
        if (context.phase == InputActionPhase.Started)
        {
            this.SetCannonInput(true);
        }
        else if (context.phase == InputActionPhase.Canceled)
        {
            this.SetCannonInput(false);
        }
    }
}
