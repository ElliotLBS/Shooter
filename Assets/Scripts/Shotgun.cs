using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Shotgun : Weapon
{
   

    public float shotgundamage = 50f;

    public override void Startup()
    {
      
            print("Boom Shotgun");
          maxAmmo = 2;
           currentdamage = 50;
          currentrange = 100;
          currentfirerate = 2;
        
    }
  }


