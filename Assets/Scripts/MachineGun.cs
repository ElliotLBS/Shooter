using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MachineGun : Weapon
{
   



    public override void SpecialShooting()
    {
        Debug.Log("Granade2");
        if (Time.deltaTime >= NextTimeToFireGranade)
        {
            NextTimeToFireGranade = Time.time + 1f / GranadeFirerate;
            Instantiate(playerGranadebulletspawner, transform.position, transform.rotation);

            Debug.Log("Granade3");
            RaycastHit hit;
            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, baserange))
            {
                Debug.Log(hit.transform.name);
                Target target = hit.transform.GetComponent<Target>();
                if (target != null)
                {
                    target.TakeDamage(Granadedamage);

                }
            }
        }
    }

    public override void Startup()
    {
        if (view.IsMine)
        {
            print("Pang Pang MachineGun");
            Debug.Log("Granade1");
            maxAmmo = 30;
            currentdamage = 10;
            currentrange = 25;
            currentfirerate = 6f;
        }
    }
        /*
        public void GranadeShooting()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                Debug.Log("Granade2");
                if (Time.time >= NextTimeToFireGranade)
                {

                    NextTimeToFireGranade = Time.time + 1f / GranadeFirerate;
                    SpecialShooting();
                    Instantiate(playerGranadebulletspawner, transform.position, transform.rotation);
                }
            }
        }
        */
 }
    
