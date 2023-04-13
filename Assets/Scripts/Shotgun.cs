using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{

    public float shotgundamage = 50f;
    public override void Start()
    {
        print("Boom Shotgun");
        maxAmmo = 2;
        currentdamage = 50;
        currentrange = 10;
        currentfirerate = 3;

     }
  }


