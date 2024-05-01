using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float playerSpeed = 1337;
    [SerializeField] float mouseSensitivity = 180;
    [SerializeField] float jumpForce = 10;

    [SerializeField] LayerMask jumpableLayers;
    [SerializeField] Vector3 groundCheckPosition;
    [SerializeField] float groundCheckRadius;

    float totalRotX = 0;
    float totalRotY = 0;

    bool isGrounded;
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

        isGrounded = Physics.CheckSphere(transform.position + groundCheckPosition, groundCheckRadius, jumpableLayers);

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
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

        //moveDirection = Camera.main.transform.forward * z + Camera.main.transform.right * x;
        moveDirection = transform.forward * z + transform.right * x;
    }

    void ApplyMovement()
    {
        //playerRigidbody.velocity = moveDirection * playerSpeed * Time.deltaTime;
        playerRigidbody.velocity = new Vector3(moveDirection.normalized.x * playerSpeed * Time.deltaTime, playerRigidbody.velocity.y, moveDirection.normalized.z * playerSpeed * Time.deltaTime);
    }

    void CalculateRotation()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        totalRotY += mouseY;
        totalRotX += mouseX;
    }
    
    void ApplyRotation()
    {
        Camera.main.transform.localRotation = Quaternion.Euler(-totalRotY, 0, 0);
        playerRigidbody.rotation = Quaternion.Euler(0, totalRotX, 0);
    }

    void Jump()
    {
        playerRigidbody.velocity += new Vector3(0, jumpForce, 0);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawSphere(transform.position + groundCheckPosition, groundCheckRadius);
    }
}
