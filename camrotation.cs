using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camrotation : MonoBehaviour
{
    public Transform player;
    public float camSense = 100f;
    private float vertRot = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        RotateCamera();
    }
    void RotateCamera()
    {
        float mouseX = Input.GetAxis("Mouse X") * camSense * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * camSense * Time.deltaTime;

        player.Rotate(Vector3.up * mouseX);

        vertRot -= mouseY;
        vertRot = Mathf.Clamp(vertRot, -45f, 45f); 
        transform.localRotation = Quaternion.Euler(vertRot, 0f, 0f);
    }
}