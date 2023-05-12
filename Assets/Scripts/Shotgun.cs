using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shotgun : Weapon
{
    public override void Startup() // Simpelt här overridar vi void Startup() från CameraSwitch scriptet med nya värden för vi bytte vapen
    {
            print("Boom Shotgun");
          maxAmmo = 2;
           currentdamage = 50;
          currentrange = 100;
          currentfirerate = 2;
        
    }
  }


