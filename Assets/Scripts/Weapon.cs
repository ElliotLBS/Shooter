using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : CameraSwitch
{
    public int maxAmmo;
    public int ammo;
    public int currentdamage;
    public float currentrange;
    public float currentfirerate;

    [SerializeField]
    private GameObject playerbulletspawner;

    public bool Rayhit;

    public float basedamage = 10f;
    public float baserange = 100f;
    public float basefireRate = 0f;
    public Camera fpscam;

    private float NextTimeToFire = 0f;

    [SerializeField]
    LayerMask layermask;

    public float NextTimeToFireGranade = 10f;
    [SerializeField]
    public GameObject playerGranadebulletspawner;

    public float Granadedamage = 100f;
    public float GranadeFirerate = 15f;
    // Start is called before the first frame update
    void Start()
    {

    }

    public void Shooting()
    {
        print("boom vanligt vapen");
        print("Instantiate2");
        //Skpaa ett skott och få det att åka framåt
        if (Time.time >= NextTimeToFire)
        {

            NextTimeToFire = Time.time + 1f / currentfirerate;
            shoot();
            Instantiate(playerbulletspawner, transform.position, transform.rotation);
            print("Instantiate3");
        }

        void shoot()
        {
            RaycastHit hit;
            if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, currentrange))
            {
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
        ammo = maxAmmo;
        print("Reload");
    }

    // Update is called once per frame
    void Update()
    {

    }
}
