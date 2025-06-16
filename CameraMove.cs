using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public float mouseSensitivity = 50f;
    public Transform player; 
    public float farer = 10f;
    public float height = 1f;

    private float rotate_x = 0f;  
    private float rotate_y = 0f;  

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        rotate_x -= mouseY;
        rotate_x = Mathf.Clamp(rotate_x, -90f, 90f);


        rotate_y += mouseX;
        transform.localRotation = Quaternion.Euler(rotate_x, rotate_y, 0f);
        player.Rotate(Vector3.up * mouseX);

        Vector3 targetPosition = player.position - transform.forward * farer + Vector3.up * height;
        transform.position = targetPosition;
    }
}