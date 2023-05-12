using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Sniper : Weapon
{  
    [SerializeField]
    private Camera cam;
    public float defaultFov = 90;  
    public override void Startup() // här overridar vi void Startup() från CameraSwitch scriptet, med att vi lägger in nya värden för vi bytte vapen
    {
            maxAmmo = 1;
            currentdamage = 100;
            currentrange = 100000000;
            currentfirerate = 4;  
    }
    public void Scope() //På void Scope() så halverar vi kamerans fieldofview med 3, så 90 /3 = 30
    {
        cam.fieldOfView = (defaultFov / 3);
    }
    public void nonScope()// I void nonScope() så säger vi att kameran kommer hålla sig på defaultfov, som är 90
    {
        cam.fieldOfView = (defaultFov);
    }

}
