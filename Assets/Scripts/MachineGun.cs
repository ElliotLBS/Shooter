using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MachineGun : Weapon
{
    public override void Startup() // Vi overridar void Startup() fr�n CameraSwitch scriptet med nya v�rden f�r man bytte vapen
    { 
            maxAmmo = 30;
            currentdamage = 10;
            currentrange = 100000;
            currentfirerate = 0.5f;       
    }
      
 }
    
