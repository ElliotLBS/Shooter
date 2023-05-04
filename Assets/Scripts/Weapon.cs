using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class Weapon : CameraSwitch
{
 

    [SerializeField]
    private GameObject playerbulletspawner;

    public bool Rayhit;

    public Camera fpscam;



    [SerializeField]
    LayerMask layermask;

    public float NextTimeToFireGranade = 10f;
    [SerializeField]
    public GameObject playerGranadebulletspawner;

    public float Granadedamage = 100f;
    public float GranadeFirerate = 15f;

    public float basedamage = 10f;
    public float baserange = 100f;
    public float basefireRate = 0f;

    // Start is called before the first frame update
   

    public virtual void Shooting()
    {
        if (view.IsMine)
        {
                RaycastHit hit;
                if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, currentrange))
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

    public virtual void SpecialShooting()
    {
        Debug.Log("Granade2");
        if (Time.deltaTime >= NextTimeToFireGranade)
        {

            NextTimeToFireGranade = Time.deltaTime + 1f / GranadeFirerate;
            SpecialShooting();
            Instantiate(playerGranadebulletspawner, transform.position, transform.rotation);
        }
    }

    public virtual void Reload()
    {
        if(view.IsMine)
        { 
           ammo = maxAmmo;
          print("Reload");
        }
    }

    // Update is called once per frame
    void Update()
    { 
        if(view.IsMine)
        {
        Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
        Debug.DrawRay(transform.position, forward, Color.green);
        }
    }
}
