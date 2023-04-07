using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{


    float speed = 35;
    private BoxCollider bc;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        transform.position += transform.forward * speed * Time.deltaTime;

    }

    public virtual void Weapons(Collision collision)
    {

    }
    private void OnCollisonEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Weapons(collision);
            Destroy(gameObject);
            SoundManager.PlaySound("enemyDeathSound");
            print("Hit Enemy");



        }
    }
}
