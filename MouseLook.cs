using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSenstiviy = 100.0f;
    public Transform playerBody;
    float xRotation = 0f;
    float sideRecoil = 0f;
    float upRecoil = 0f;
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;    
    }
    void Update()
    {
        float mouseX = sideRecoil + Input.GetAxis("Mouse X") * mouseSenstiviy * Time.deltaTime;
        float mouseY = upRecoil + Input.GetAxis("Mouse Y") * mouseSenstiviy * Time.deltaTime;
        sideRecoil = 0;
        upRecoil = 0;
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }

    public void AddRecoil(float side, float up)
    {
        sideRecoil += side;
        upRecoil += up;
    }
}
