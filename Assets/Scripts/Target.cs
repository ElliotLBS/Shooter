
using UnityEngine;
using Photon.Pun;



public class Target : MonoBehaviour
{
    [SerializeField]
    CharacterController controller;

    public int maxHealth = 100;
    public int currentHealth;
    public Healthbar healthbar;

    float minX = -17;
    float maxX = 16;
    float minY = 1;
    float maxY = 1;
    float minZ = -17;
    float maxZ = 16;

    PhotonView view;





    // Här skaffar den Photon och photon kameran.
    void Start()
    {
        view = GetComponent<PhotonView>();
        currentHealth = maxHealth;
      //  healthbar.SetMaxHealth(maxHealth);
      

    }
    //I void TakeDamage() sägs så att om spelarens health blir mindre eller är noll kommer den att "dö"
    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        //healthbar.SetHealth(currentHealth);
        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy") //Med detta ser vi att om vi träffar något med taggen "Enemy" kommer gameobject att förstöras

            {
                Die();
             }
            else // Men om den inte har taggen "Enemy" kommer den ändra positionen för den andra spelaren 
            {
                view.RPC("PlayerDie", RpcTarget.All);
             }
        }
        void Die()
        {
            Destroy(gameObject);
        }
    }
  
    [PunRPC]
    public void PlayerDie()
    {
        controller.enabled = false;

        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        controller.enabled = true;

    }
 

}

