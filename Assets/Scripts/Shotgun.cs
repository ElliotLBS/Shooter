using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public override void Startup() // Simpelt h�r overridar vi void Startup() fr�n CameraSwitch scriptet med nya v�rden f�r vi bytte vapen
    {
            print("Boom Shotgun");
          maxAmmo = 2;
           currentdamage = 50;
          currentrange = 100;
          currentfirerate = 2;
        
    }
  }


