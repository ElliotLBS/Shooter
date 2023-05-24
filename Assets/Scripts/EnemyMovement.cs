using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField]
    float speed;
    public Vector3 direction = new Vector3(0, 0, 0);
    Rigidbody rb;
   

    void Start() 
    {
        rb = GetComponent<Rigidbody>();
        int x = Random.Range(0, 2);
        if (x == 0) // här kollar vi om vilket håll den spawnade på, om dens x är 0 kommer den ändras till 1, annars kommer den vara 2
        {
            x = -1;
        }
        direction.x = x;
    }

    void Update()  // Den går konstant åt den direction där den spawnade från
    {
        rb.position += direction * speed * Time.deltaTime;
    }


}
