using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Buzzing : MonoBehaviour
{
    public Rigidbody rb;
    public float forceBuzz = 0.1f; //Part of the enemy

    private Transform target;

    enum Direction
    {
        LEFT = 0,
        RIGHT,
        UP,
        DOWN
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        Buzz();
    }

    void Buzz()
    {
        int lengthOfEnumDirectionList = System.Enum.GetValues(typeof(Direction)).Length;
        Direction dir = (Direction)Random.Range(0, lengthOfEnumDirectionList);

        switch (dir)
        {
            case Direction.LEFT:
                rb.AddForce(-forceBuzz * transform.right, ForceMode.Impulse);
                break;
            case Direction.RIGHT:
                rb.AddForce(forceBuzz * transform.right, ForceMode.Impulse);
                break;
            case Direction.UP:
                rb.AddForce(forceBuzz * transform.up, ForceMode.Impulse);
                break;
            case Direction.DOWN:
                rb.AddForce(-forceBuzz * transform.up, ForceMode.Impulse);
                break;

        }

    }


}
