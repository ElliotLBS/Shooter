using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerScript : MonoBehaviour
{
    public CharacterController controller;

    Vector3 velocity;
    public float gravity = -9.82f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    bool isGrounded;
    public float jumpheight = 3f;

    public float runSpeed = 20f;
    public float walkSpeed = 12f;
    public float speed = 12f;

    public float standTimer;

    PhotonView view;
    float minX = -17;
    float maxX = 16;
    float minY = 1;
    float maxY = 1;
    float minZ = -17;
    float maxZ = 16;
    void Start() // Den f�ngar in photon och dess kamera, p� andra s�ger vi om viewn inte �r ens egen s� kommer den h�mta cameran en ens gameobject, s� med andra ord kommer spelare ha olika photon views
    {
        view = GetComponent<PhotonView>();
        if (!view.IsMine)
        {
            GetComponentInChildren<Camera>().gameObject.SetActive(false);
        }

    }
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey(KeyCode.LeftShift)) // Vi s�ger om man h�ller in shift s� kommer man kunna f� en stor hastiget
            {
                speed = runSpeed;
            }
            else // om man inte h�ller in shift s� kommer ha vanlig g� hastiget
            {
                speed = walkSpeed;
            }
            if (Input.GetButtonDown("Jump") && isGrounded) // om man trycker p� "Space" s� kommer man flyga upp f�r att sedan �ka ner gravitet
            {
                velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);
                standTimer = 0;

            }
            //Allt nedan g�r bara s� att man kan r�ra sig genom "x,y,z" 
            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);
            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y <= 0) // Om  man st�r p� en platfrom och hastigeten �r mindre �n noll, kommer s�tta s� att man inte flyger upp men att man st�r p� platformen
             {
                velocity.y = -2f;
                if (Physics.OverlapSphere(groundCheck.position, groundDistance, groundMask)[0].gameObject.CompareTag("BPlatform"))
                { // Om man st�r p� en platform med taggen "BPlatform" s� kommer den starta en standTimer
                    standTimer += Time.deltaTime;
                }
            }
            if (standTimer >= 0.5) // om standTimer �r mer �n 0.5 sekunder s� kommer man respawna 
            {
                Respawn();
            }
        }
    }
    public void Respawn() // Om void Respawn() �r p� kommer den byta positionen p� spelaren och resetta standTimer.
    {
        controller.enabled = false;;
        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
        standTimer = 0;
        controller.enabled = true;
    }

    void OnControllerColliderHit(ControllerColliderHit hit) 
    {
       if (hit.gameObject.CompareTag("DPlatform")) // Simpelt om man collidar med n�got med tagggen "DPlatfrom" kommer man byta positionen
       {
         transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
       }

    }
}
