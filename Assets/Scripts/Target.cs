
using UnityEngine;

public class Target : MonoBehaviour
{
    public float health = 100f;
    float minX = -17;
    float maxX = 16;
    float minY = 1;
    float maxY = 1;
    float minZ = -17;
    float maxZ = 16;
    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
            if (gameObject.tag == "Enemy")
            {
                Die();
            }
            else
            {
                transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
            }
           
        }

        void Die()
        {
            Destroy(gameObject);
        }
       

    }



}

