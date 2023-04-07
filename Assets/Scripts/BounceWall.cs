using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 lastVelocity;
    EnemyMovement movement;

    private void Awake()
    {
        movement = GetComponent<EnemyMovement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall")
        {
            movement.direction.x = -movement.direction.x;

        }

        if (collision.gameObject.tag == "UpperWall")
        {
            // direction.y = -direction.y;
        }

        if (transform.position.y < collision.transform.position.y)
        {
            //  direction.y = -1;
        }
        else
        {
            // direction.y = 1;
        }
    }
}
