using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed = 35;
    void Update() // h�r g�r vi s� att skottet bara �ker fram�t fr�n d�r den instaniatestet
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

   public virtual void Weapons(Collision collision) // H�r s� Weapons har sin referens och vi s�ger till att vi g�r den collidable
    {

    }
    private void OnCollisonEnter(Collision collision) // P� detta s�ger vi att om skottet kolliderar med n�got med taggen "Enemy" kommer den f�rst�ra skottet
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Weapons(collision);
            Destroy(gameObject);
            SoundManager.PlaySound("enemyDeathSound");
        



        }
    }
}
