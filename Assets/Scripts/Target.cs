
using UnityEngine;
using Photon.Pun;


public class Target : MonoBehaviour
{
    protected PhotonView view;

    public float health = 100f;
    float minX = -17;
    float maxX = 16;
    float minY = 1;
    float maxY = 1;
    float minZ = -17;
    float maxZ = 16;

    void Start()
    {
        view = GetComponent<PhotonView>();
    }

    public void TakeDamage(float amount)
    {
        health -= amount;
        if (health <= 0)
        {
             if (gameObject.tag == "Enemy")
             {
                 Die();
             }   
            if(view.IsMine)
            {
            PlayerDie();
             }


/*
             if (gameObject.tag == "Player2")
             {
                 transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
             }
            */
        }

        void Die()
        {
            Destroy(gameObject);
        }
        void PlayerDie()
        {
            transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        }
       

    }



}

