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
        if (x == 0) // h�r kollar vi om vilket h�ll den spawnade p�, om dens x �r 0 kommer den �ndras till 1, annars kommer den vara 2
        {
            x = -1;
        }
        direction.x = x;
    }

    void Update()  // Den g�r konstant �t den direction d�r den spawnade fr�n
    {
        rb.position += direction * speed * Time.deltaTime;
    }


}
