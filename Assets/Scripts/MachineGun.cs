using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MachineGun : Weapon
{
    public override void Startup() // Vi overridar void Startup() från CameraSwitch scriptet med nya värden för man bytte vapen
    { 
            maxAmmo = 30;
            currentdamage = 10;
            currentrange = 100000;
            currentfirerate = 0.5f;       
    }
      
 }
    
