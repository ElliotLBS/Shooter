using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    public float shotgundamage = 50f;
    public  void Shooting()
    {
        print("Boom Shotgun");
        maxAmmo = 2;
        currentdamage = 50;
        currentrange = 10;
        currentfirerate = 1;



    
            Target target = transform.GetComponent<Target>();
            if (target != null)
            {
                target.TakeDamage(currentdamage);
                Debug.Log("Hit With Shotgun");
            }
        
    }
}
