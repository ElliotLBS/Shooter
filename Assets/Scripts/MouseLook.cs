using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivty = 100f;
    public Transform playerBody;
    float xRotation = 0f;
    PhotonView view;
    void Start() // Den hittar photon kameran, och säger så att om man är inne i spelet kommer musen alltid vara i mitten
    {
        view = GetComponent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        if (view.IsMine)
        {
         //Allt det här gör så att man kan röra sig runt om "spelaren" och kameran kommer dras med vart än musen vill
            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivty * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivty * Time.deltaTime;
            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);
            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
