using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    float speed = 35;
    void Update() // här gör vi så att skottet bara åker framåt från där den instaniatestet
    {
        transform.position += transform.forward * speed * Time.deltaTime;
    }

   public virtual void Weapons(Collision collision) // Här så Weapons har sin referens och vi säger till att vi gör den collidable
    {

    }
    private void OnCollisonEnter(Collision collision) // På detta säger vi att om skottet kolliderar med något med taggen "Enemy" kommer den förstöra skottet
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Weapons(collision);
            Destroy(gameObject);
            SoundManager.PlaySound("enemyDeathSound");
        



        }
    }
}
