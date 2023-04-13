using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sniper : Weapon
{
    [SerializeField]
    private Camera cam;

    public float defaultFov = 90;

    public override void Start()
    {
        print("Pang sniper");
        maxAmmo = 1;
        currentdamage = 100;
        currentrange = 100;
        currentfirerate = 1;
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
