using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : Timer
{
    [Header("=== Missile ===")]
    public Transform player;

    public float explosionTimer = 3.0f;
    public float lookAtSpeed = 2.0f;

    private Rigidbody rb;

    public float missileAcceleration = 10f;
    public float topSpeed = 10f;
    public float ejectSpeed = 4f;

    public float deployTime = 2f;

    public float damage = 5f;

    public enum Direction
    {
        LEFT,
        RIGHT,
        UP,
        DOWN,
        FORWARD,
        BACKWARD
    }
    public Direction ejectDirection = Direction.LEFT;
    private Vector3 ejectDirectionVector;

    enum Phase
    {
        EJECT,
        ACCELERATE,
        WAIT
    }

    Phase phase = Phase.EJECT;

    void Start()
    {
        Init();
    }

    void Update()
    {
        if (player == null)
        {
            return;
        }

        if (GetTimerStopped() == false)
        {
            UpdateTimer();
        }
        else
        {
            Explode();
        }

        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, lookAtSpeed * Time.deltaTime);

        switch (phase)
        {
            case Phase.EJECT:
                rb.velocity = ejectDirectionVector * ejectSpeed;
                Invoke("Accelerate", deployTime);
                phase = Phase.WAIT;
                break;
            case Phase.WAIT:
                // Do nothing because Invoke was called.
                break;
            case Phase.ACCELERATE:
                Accelerate();
                break;
        }
    }

    void Accelerate()
    {
        // Force acceleration phase, nothing can stop this missile from
        // accelerating now! Unless something external change phase.
        phase = Phase.ACCELERATE;
        rb.AddForce(missileAcceleration * transform.forward, ForceMode.Acceleration);

        // Cap top speed of missile so it doesn't accelerate any further.
        if (rb.velocity.magnitude >= topSpeed)
        {
            rb.velocity = topSpeed * transform.forward;
        }

        // Check if missile has reached player (you can implement a proximity check here)
        if (Vector3.Distance(transform.position, player.position) <= 3.0f)
        {
            Explode();
        }

    }

    void Explode()
    {
        // force health to become 0 when timer is up.
        if (this.TryGetComponent<HealthComponent>(out HealthComponent health))
        {
            health.curHealth = 0;
        }
    }

    public void Init()
    {
        phase = Phase.EJECT;

        ResetTimer();
        timerSet = explosionTimer;

        ResetHealth();

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();

        switch (ejectDirection)
        {
            case Direction.LEFT:
                ejectDirectionVector = -transform.right;
                break;
            case Direction.RIGHT:
                ejectDirectionVector = transform.right;
                break;
            case Direction.UP:
                ejectDirectionVector = transform.up;
                break;
            case Direction.DOWN:
                ejectDirectionVector = -transform.up;
                break;
            case Direction.FORWARD:
                ejectDirectionVector = transform.forward;
                break;
            case Direction.BACKWARD:
                ejectDirectionVector = -transform.forward;
                break;
        }


        //Invoke("Explode", explosionTimer);
    }

    void ResetHealth()
    {
        if (this.TryGetComponent<HealthComponent>(out HealthComponent health))
        {
            health.curHealth = health.initHealth;
        }
    }
}
