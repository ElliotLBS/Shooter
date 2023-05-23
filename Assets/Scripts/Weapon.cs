using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Weapon : CameraSwitch
{
 
    [SerializeField]
    private GameObject playerbulletspawner;
    public Camera fpscam;
  

   
    //I  void Shooting() så kommer scripten ha en raycast som kommer hålla sig framför spelaren och följa efter kameran, för att sedan kunna göra skada 
    public virtual void Shooting()
    {
        if (view.IsMine)
        {
            RaycastHit hit;
            if (Physics.Raycast(fpscam.transform.position + fpscam.transform.forward * 1, fpscam.transform.forward, out hit, currentrange))
            {
                Instantiate(playerbulletspawner, transform.position, transform.rotation);
                //Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(currentdamage);
                }

            }
        }
    }
   // Om man trycker på "R" eller ammot är slut kommer ammot bli till maxammo
    public virtual void Reload()
    {
        if(view.IsMine)
        { 
           ammo = maxAmmo;
        }
    }
    //Detta är bara ett test för att kolla vart min raycast pekar när man siktar
    void Update()
    { 
        if(view.IsMine)
        {
            Ray ray = new Ray(fpscam.transform.position, fpscam.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);
           


        }
    }
}
