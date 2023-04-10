using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sniper : Weapon
{
    [SerializeField]
    private Camera cam;

    public  void Shooting()
    {
        print("Pang sniper");
        maxAmmo = 1;
        currentdamage = 100;
        currentrange = 50;
        currentfirerate = 1;
    }
    void Scope()
    {
        if (Input.GetButtonDown("Fire2")) //om inget händer kommer detta att hända
        {
            print("zoom");
            Camera.main.fieldOfView = 30;

        }
        //Siktar in
    }
}
