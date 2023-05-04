using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Sniper : Weapon
{
   

    [SerializeField]
    private Camera cam;

    public float defaultFov = 90;
    
    public override void Startup()
    {
            print("Pang sniper");
            maxAmmo = 1;
            currentdamage = 100;
            currentrange = 100;
            currentfirerate = 4;
        
    }
    public void Scope()
    {

        cam.fieldOfView = (defaultFov / 3);
        //Siktar in
    }
    public void nonScope()
    {

        cam.fieldOfView = (defaultFov);
    }

}
