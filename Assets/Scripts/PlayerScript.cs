using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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


    Rigidbody rb;
    BoxCollider boxCollider;

    [SerializeField]
    Transform destination;

    




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        boxCollider = transform.GetComponent<BoxCollider>();
       
    }

    // Update is called once per frame
    void Update()
    {


      

        

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = runSpeed;
        }
        else
        {
            speed = walkSpeed;
        }

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y <= 0)
        {
            velocity.y = -2f;
            if (Physics.OverlapSphere(groundCheck.position, groundDistance, groundMask)[0].gameObject.CompareTag("BPlatform"))
            {
                startStandTimer = true;
                standTimer += Time.deltaTime;
            }

        }
        if (startStandTimer)
        {
            if (standTimer >= 0.5)     //om det har g�tt 5 sekunder eller mer, Theo
            {

                startStandTimer = false;
                transform.position = destination.position;
                standTimer = 0;
            }
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
    }

    void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.gameObject.CompareTag("DPlatform"))
        {
            transform.position = destination.position;
            //hit.transform.position = destination.position;
      
        }
    }



}