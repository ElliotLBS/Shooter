using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Weapon : CameraSwitch
{
 
    [SerializeField]
    private GameObject playerbulletspawner;
    public Camera fpscam;
  

   
    //I  void Shooting() s� kommer scripten ha en raycast som kommer h�lla sig framf�r spelaren och f�lja efter kameran, f�r att sedan kunna g�ra skada 
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
   // Om man trycker p� "R" eller ammot �r slut kommer ammot bli till maxammo
    public virtual void Reload()
    {
        if(view.IsMine)
        { 
           ammo = maxAmmo;
        }
    }
    //Detta �r bara ett test f�r att kolla vart min raycast pekar n�r man siktar
    void Update()
    { 
        if(view.IsMine)
        {
            Ray ray = new Ray(fpscam.transform.position, fpscam.transform.forward);
            Debug.DrawRay(ray.origin, ray.direction * 100f, Color.green);
           


        }
    }
}
