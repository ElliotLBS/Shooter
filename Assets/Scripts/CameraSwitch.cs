using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    Weapon[] weapons;
    public int currentWeapon = 0;

    [SerializeField]
    Weapon weapon;

    [SerializeField]
    Sniper sniper;

    protected PhotonView view;
    private float NextTimeToFire = 0f;
    public int maxAmmo;
    public int ammo;
    public int currentdamage;
    public float currentrange;
    public float currentfirerate;

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        weapons = GetComponents<Weapon>();
    }
    public virtual void Startup()
    {

        print("boom vanligt vapen");
        maxAmmo = 10;
        ammo = 10;
        currentdamage = 20;
        currentrange = 30;
        currentfirerate = 2;
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
       
            if (Input.GetButtonDown("Fire1") && weapons[currentWeapon].ammo > 0 && Time.time >= NextTimeToFire) //om inget händer kommer detta att hända
            {
                // print("Tiden är " + Time.time + " och nexttime är " + NextTimeToFire);
                //weapon.ammo--;
                ammo--;
                print("ammo-");
                weapons[currentWeapon].Shooting();
                print("bang");
                NextTimeToFire = Time.time + currentfirerate;


            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                weapons[currentWeapon].SpecialShooting();
            }
            if (weapons[currentWeapon].ammo <= 0 || Input.GetKeyDown(KeyCode.R))
            {
                weapons[currentWeapon].Reload();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                currentWeapon++;
                print("SwitchWeapon");
                if (currentWeapon >= weapons.Length)
                {
                    currentWeapon = 0;
                }
            }
            if (Input.GetButton("Fire2") && currentWeapon == 3)
            {
                sniper.Scope();

            }
            else
            {
                sniper.nonScope();

            }
        }
    }
}
