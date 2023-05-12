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

    void Start() // hämtar komipinenter för scriptet 
    {
        view = GetComponent<PhotonView>();
        weapons = GetComponents<Weapon>();
    }
    public virtual void Startup() //denna är en virtual void Startup() som sätter värden för det som kommer användas i andra scripts eller klasser
    {

        maxAmmo = 10;
        ammo = 10;
        currentdamage = 20;
        currentrange = 1000;
        currentfirerate = 2;
    }

    void Update()
    {
        if (view.IsMine)
        {
       
            if (Input.GetButtonDown("Fire1") && weapons[currentWeapon].ammo > 0 && Time.time >= NextTimeToFire) 
            { // Om jag trycker på vänsterklick och man har valt ett vapen och ammo inte är noll och man har rätten att skjuta 
                // Kommer man kunna skjuta ett skott i Weapon scriptet
                ammo--;
                weapons[currentWeapon].Shooting();
                NextTimeToFire = Time.time + currentfirerate;


            }
         
            if (weapons[currentWeapon].ammo <= 0 || Input.GetKeyDown(KeyCode.R)) //om man har slut på ammo eller trycker på R kommer man reloada i Weapon scriptet
            {
                weapons[currentWeapon].Reload();
            }
            if (Input.GetKeyDown(KeyCode.E)) // Man byter vapen genom att trycka på E, och sätter den en + i arrayen av vapen
            {
                currentWeapon++;
                if (currentWeapon >= weapons.Length)
                {
                    currentWeapon = 0;
                }
            }
            if (Input.GetButton("Fire2") && currentWeapon == 3) // Om man håller in högerklick och håller i snipern så kommer den sikta i Sniper scriptet
            {
                sniper.Scope();

            }
            else // annars kommer siktet vara normal
            {
                sniper.nonScope();

            }
        }
    }
}
