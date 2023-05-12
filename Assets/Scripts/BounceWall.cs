using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BounceWall : MonoBehaviour
{
    private Rigidbody rb;
    Vector3 lastVelocity;
    EnemyMovement movement;

    private void Awake() // h�mtar kompinenter f�r scripet
    {
        movement = GetComponent<EnemyMovement>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update() //dens senaste hastiget �r rigidbodyin's hastiget
    {
        lastVelocity = rb.velocity;
    }
    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Wall") // Om den kolliderar med n�got med taggen "Wall" kommer den att byta den direction till emot
        {
            movement.direction.x = -movement.direction.x;

        }
    }
}
