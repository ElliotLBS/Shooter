using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraSwitch : MonoBehaviour
{
    [SerializeField]
    Weapon[] weapons;
    public int currentWeapon = 0;

    // Start is called before the first frame update
    void Start()
    {
        weapons = GetComponents<Weapon>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1")) //om inget händer kommer detta att hända
        {
            print("CurrentWeapon");
            weapons[currentWeapon].Shooting();
            print("Instantiate1");
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
    }
}
