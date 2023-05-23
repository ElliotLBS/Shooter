using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Avatar : MonoBehaviour, Ikillable, IDamageable<float>
{
    public void Kill()
    {
        //Kill all with tag "Enemy"
    }
    public void Damage(float damageTaken)
    {
        //Damage all like 20hp
    }

}
