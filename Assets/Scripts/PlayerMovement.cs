using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1337;
    [SerializeField] float mouseSensitivity = 180;

    //float yRotation = 0;
    float totalRot = 0;
    Vector3 moveDirection;

    Rigidbody playerRigidbody;
    
    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    void Update()
    {
        Cursor.lockState = CursorLockMode.Locked;

        CalculateMovement();
        CalculateRotation();
        //Rotate();
    }

    void FixedUpdate()
    {
        ApplyMovement();
        ApplyRotation();
    }

    void CalculateMovement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        moveDirection = transform.forward * z + transform.right * x;
    }

    void ApplyMovement()
    {
        //playerRigidbody.velocity = moveDirection * playerSpeed * Time.deltaTime;
        playerRigidbody.velocity = new Vector3(moveDirection.normalized.x * playerSpeed * Time.deltaTime, playerRigidbody.velocity.y, moveDirection.normalized.z * playerSpeed * Time.deltaTime);
    }

    void CalculateRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        totalRot += mouseX;
    }
    
    void ApplyRotation()
    {
        playerRigidbody.rotation = Quaternion.Euler(0, totalRot, 0);
    }
}
