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

    public bool startStandTimer;
    public float standTimer;


    //Rigidbody rb;
    //BoxCollider boxCollider;

    // [SerializeField]
    //Transform destination;

    public bool respawn;
    public float standingtimer = 3f;
    public bool Standing = false;

    PhotonView view;
    float minX = -17;
    float maxX = 16;
    float minY = 1;
    float maxY = 1;
    float minZ = -17;
    float maxZ = 16;


    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        //  rb = GetComponent<Rigidbody>();
        // boxCollider = transform.GetComponent<BoxCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                speed = runSpeed;
            }
            else
            {
                speed = walkSpeed;
            }
            if (Input.GetButtonDown("Jump") && isGrounded)
            {
                velocity.y = Mathf.Sqrt(jumpheight * -2f * gravity);

            }

            float x = Input.GetAxis("Horizontal");
            float z = Input.GetAxis("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;

            controller.Move(move * speed * Time.deltaTime);

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

          /*  if (respawn)
            {
                transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
                Restartrespawn();
            }
            if (standingtimer < 0)
            {
                respawn = true;
            
                standingtimer = 3f;

            }
            if (Standing)
            {
                standingtimer -= Time.deltaTime;
            }
          */
            isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

            if (isGrounded && velocity.y <= 0)
            {
                velocity.y = -2f;
                if (Physics.OverlapSphere(groundCheck.position, groundDistance, groundMask)[0].gameObject.CompareTag("BPlatform"))
                {
                    startStandTimer = true;
                    standTimer += Time.deltaTime;
                }
                else
                {
                    startStandTimer = false;
                    standTimer = 0;
                }

            }
            if (startStandTimer)
            {
                if (standTimer >= 0.5)     //om det har g�tt 5 sekunder eller mer
                {

                    Respawn();
                 
                    standTimer = 0;
                    startStandTimer = false;
                }
            }

        }


    }
    public void  Restartrespawn()
    {
        respawn = false;
    }
    public void Restartstandingtimer()
    {
        standingtimer = 3f;
    }
    public void Respawn()
    {
        transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
            {
               
                   if (hit.gameObject.CompareTag("DPlatform"))
                   {

                     transform.position = new Vector3(Random.Range(minX, maxX), Random.Range(minY, maxY), Random.Range(minZ, maxZ));
                    //hit.transform.position = destination.position;

                   }
                     if (hit.gameObject.CompareTag("BPlatform"))
                     {

                       Standing = true;
                     }
                    else
                    {
                      Standing = false;

                      standingtimer = 3f;
                    }
               
            }
        
    



}
