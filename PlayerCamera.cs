using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float moveSpeed = 5f;
    private camrotate cameraController;
    private Rigidbody rb;

    void Start()
    {
        GameObject cameraObject = GameObject.FindGameObjectWithTag("Player Camera");
        if (cameraObject != null)
        {
            cameraController = cameraObject.GetComponent<camrotate>(); // rotate
        }
        else
        {
            Debug.LogError("Camera not found");
        }

        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

    // Update the player movement
    void Update()
    {
        float moveHorizontal = Input.GetKey(KeyCode.A) ? -1 : (Input.GetKey(KeyCode.D) ? 1 : 0);
        float moveVertical = Input.GetKey(KeyCode.W) ? 1 : (Input.GetKey(KeyCode.S) ? -1 : 0);

        Vector3 moveDirection = new Vector3(moveHorizontal, 0f, moveVertical);
        moveDirection = cameraController.GetRelativeDirection(moveDirection);

        // Apply movement using the Rigidbody to respect physics
        rb.velocity = new Vector3(moveDirection.x * moveSpeed, rb.velocity.y, moveDirection.z * moveSpeed);
    }
}