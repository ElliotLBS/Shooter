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
    // Start is called before the first frame update
    void Start()
    {
        view = GetComponent<PhotonView>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        if (view.IsMine)
        {

            float mouseX = Input.GetAxis("Mouse X") * mouseSensitivty * Time.deltaTime;
            float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivty * Time.deltaTime;

            xRotation -= mouseY;
            xRotation = Mathf.Clamp(xRotation, -90f, 90f);

            transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
            playerBody.Rotate(Vector3.up * mouseX);
        }
    }
}
