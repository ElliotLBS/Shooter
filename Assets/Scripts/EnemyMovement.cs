using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{


    [SerializeField]
    float speed;
    public Vector3 direction = new Vector3(0, 0, 0);
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        int x = Random.Range(0, 2);
        if (x == 0)
        {
            x = -1;
        }
        direction.x = x;

    }

    // Update is called once per frame
    void Update()
    {
        rb.position += direction * speed * Time.deltaTime;
        // transform.position += 
    }


}
