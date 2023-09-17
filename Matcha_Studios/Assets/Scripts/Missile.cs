using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missile : MonoBehaviour
{
    public Transform player;
    public float acceleration = 2.0f;
    public float maxSpeed = 10.0f;
    public float explosionTimer = 3.0f;

    private Rigidbody rb;
    private float currentSpeed = 0.0f;
    private bool accelerating = true;

    public float ejectForce = 4f;
    
    public Timer ejectTimer;
    public float setEjectTimer = 10f;

    public Timer waitTimer;
    public float setWaitTimer = 0.1f;

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
        ejectTimer = gameObject.AddComponent<Timer>();
        ejectTimer.timerSet = setEjectTimer;

        waitTimer = gameObject.AddComponent<Timer>();
        waitTimer.timerSet = setWaitTimer;


        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = GetComponent<Rigidbody>();
        //rb.velocity = ejectDirection * currentSpeed;

        switch(ejectDirection)
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

        
        Invoke("Explode", explosionTimer);
    }

    void Update()
    {
        switch(phase)
        {
            case Phase.EJECT:
                //rb.AddForce(ejectForce * ejectDirectionVector, ForceMode.Acceleration);
                if(ejectTimer.GetTimerStopped() == false)
                {
                    ejectTimer.UpdateTimer();
                    Eject();
                }
                else
                {
                    // immediately switch to ACCELERATE mode
                    phase = Phase.WAIT; 
                }
                break;
            case Phase.WAIT:
                
                if (waitTimer.GetTimerStopped() == false)
                {
                    waitTimer.UpdateTimer();
                }
                else
                {
                    // immediately switch to ACCELERATE mode
                    phase = Phase.ACCELERATE;
                }
                break;
            case Phase.ACCELERATE:
                Accelerate();
                break;
        }
        
    }

    void Eject()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        if (accelerating)
        {
            currentSpeed += ejectForce * Time.deltaTime; //is a short push per deltatime
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        }

        rb.velocity = ejectDirectionVector * currentSpeed;

        // Set the velocity to 0 so missile doesnt move.
        // rb.velocity = Vector3.Lerp(rb.velocity, Vector3.zero, setWaitTimer);

        // Check if missile has reached player (you can implement a proximity check here)
        if (Vector3.Distance(transform.position, player.position) <= 1.0f)
        {
            Explode();
        }
    }

    void Accelerate()
    {
        Vector3 directionToPlayer = (player.position - transform.position).normalized;

        if (accelerating)
        {
            currentSpeed += acceleration * Time.deltaTime; //is a short push per deltatime
            currentSpeed = Mathf.Min(currentSpeed, maxSpeed);
        }

        rb.velocity = directionToPlayer * currentSpeed;

        // Check if missile has reached player (you can implement a proximity check here)
        if (Vector3.Distance(transform.position, player.position) <= 2.0f)
        {
            Explode();
        }
    }

    void Explode()
    {
        // Implement explosion logic here
        Destroy(gameObject);
    }
}
