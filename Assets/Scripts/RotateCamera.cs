using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [SerializeField] SettingsValues SettingsObj;

    //float totalRotX = 0;
    //float totalRotY = 0;

    [SerializeField] Rigidbody playerRigidbody;

    //Ankan
    float xRotation;
    float yRotation;

    void Update()
    {
        CalculateRotation();
    }

    void FixedUpdate()
    {
        ApplyRotation();
    }

    void CalculateRotation()
    {
        //float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        //float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        //totalRotY += mouseY;
        //totalRotX += mouseX;

        //Ankan
        float MouseX = Input.GetAxis("Mouse X") * SettingsObj.sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * SettingsObj.sensitivity * Time.deltaTime;
        xRotation -= MouseY;
        yRotation += MouseX;
    }

    void ApplyRotation()
    {
        //Camera.main.transform.localRotation = Quaternion.Euler(-totalRotY, 0, 0);
        //playerRigidbody.rotation = Quaternion.Euler(0, totalRotX, 0);

        //Ankan
        xRotation = Mathf.Clamp(xRotation, 0f, 30);

        playerRigidbody.transform.rotation = Quaternion.Euler(0f, yRotation, 0f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
    }
}
