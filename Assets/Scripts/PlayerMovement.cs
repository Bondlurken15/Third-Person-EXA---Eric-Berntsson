using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1337;
    [SerializeField] float mouseSensitivity = 180;

    //float yRotation = 0;

    Rigidbody playerRigidbody;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Cursor.lockState = CursorLockMode.Locked;
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * z + transform.right * x;
        //playerRigidbody.velocity = moveDirection * playerSpeed * Time.deltaTime;
        playerRigidbody.velocity = new Vector3(moveDirection.normalized.x * playerSpeed * Time.deltaTime, playerRigidbody.velocity.y, moveDirection.normalized.z * playerSpeed * Time.deltaTime);

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        //yRotation -= mouseY;
        //yRotation = Mathf.Clamp(yRotation, -90f, 90f);

        //transform.localRotation = Quaternion.Euler(yRotation, 0f, 0f);

        playerRigidbody.transform.Rotate(Vector3.up * mouseX);
    }
}
