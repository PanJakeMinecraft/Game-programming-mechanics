using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float walk = 5f; 
    public float run = 10f; 
    public Transform cameraTransform; // The player camera
    private Rigidbody rb; 

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    void Update()
    {
        float moveX = 0f;
        float moveZ = 0f;

        if (Input.GetKey(KeyCode.W)) moveZ = 1f;
        if (Input.GetKey(KeyCode.S)) moveZ = -1f;
        if (Input.GetKey(KeyCode.A)) moveX = -1f;
        if (Input.GetKey(KeyCode.D)) moveX = 1f;

        float speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = run;
        }
        else {
            speed = walk;
        }

        Vector3 moveDirection = new Vector3(moveX, 0f, moveZ).normalized;

        if (moveDirection.magnitude >= 0.1f)
        {
            Vector3 cameraForward = cameraTransform.forward;
            cameraForward.y = 0f; 
            cameraForward.Normalize();

            Vector3 cameraRight = cameraTransform.right;
            cameraRight.y = 0f;  
            cameraRight.Normalize();

            Vector3 desiredMove = cameraForward * moveDirection.z + cameraRight * moveDirection.x;
            rb.velocity = new Vector3(desiredMove.x * speed, rb.velocity.y, desiredMove.z * speed);
        }
    }
}