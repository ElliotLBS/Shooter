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

    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        weapons = GetComponents<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        { 
            if (Input.GetButtonDown("Fire1") && weapons[currentWeapon].ammo > 0) //om inget händer kommer detta att hända
            {
                //weapon.ammo--;
                weapons[currentWeapon].Shooting();

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
