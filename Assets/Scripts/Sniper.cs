using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;


public class Sniper : Weapon
{  
    [SerializeField]
    private Camera cam;
    public float defaultFov = 90;  
    public override void Startup() // h�r overridar vi void Startup() fr�n CameraSwitch scriptet, med att vi l�gger in nya v�rden f�r vi bytte vapen
    {
            maxAmmo = 1;
            currentdamage = 100;
            currentrange = 100000000;
            currentfirerate = 4;  
    }
    public void Scope() //P� void Scope() s� halverar vi kamerans fieldofview med 3, s� 90 /3 = 30
    {
        cam.fieldOfView = (defaultFov / 3);
    }
    public void nonScope()// I void nonScope() s� s�ger vi att kameran kommer h�lla sig p� defaultfov, som �r 90
    {
        cam.fieldOfView = (defaultFov);
    }

}
