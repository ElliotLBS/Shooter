
using UnityEngine;
using Photon.Pun;



public class Target : MonoBehaviour, IPunObservable
{
    [SerializeField]
    CharacterController controller;

    public int maxHealth = 100;
    public int currentHealth;

    float minX = -17;
    float maxX = 16;
    float minY = 1;
    float maxY = 1;
    float minZ = -17;
    float maxZ = 16;

    PhotonView view;
    [SerializeField] FloatingHealtbar healthbar;
    // H�r skaffar den Photon och photon kameran.
    void Start()
    {
        view = GetComponent<PhotonView>();
        currentHealth = maxHealth;
        healthbar = transform.GetChild(0).transform.GetChild(0).GetComponentInChildren<FloatingHealtbar>();

      

    }
    //I void TakeDamage() s�gs s� att om spelarens health blir mindre eller �r noll kommer den att "d�"
    public void TakeDamage(int amount)
    {

        currentHealth -= amount;
        if(view.IsMine)
        {
            healthbar.UpdateFixedHealtBar(currentHealth, maxHealth);

        }


        if (currentHealth <= 0)
        {
            if (gameObject.tag == "Enemy") //Med detta ser vi att om vi tr�ffar n�got med taggen "Enemy" kommer gameobject att f�rst�ras

            {
                Die();
             }
            else // Men om den inte har taggen "Enemy" kommer den �ndra positionen f�r den andra spelaren 
            {
                view.RPC("PlayerDie", RpcTarget.All);
            }
        
        void Die()
        {
            Destroy(gameObject);
        }
        }
        
    }
  
    [PunRPC]
    public void PlayerDie()
    {
        controller.enabled = false;

        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        controller.enabled = true;

    }

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
      
        if (stream.IsWriting)
        {
            stream.SendNext(currentHealth);
        }
        else
        {
            currentHealth = (int)stream.ReceiveNext();
        }
        }
    
}

