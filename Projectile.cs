using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject missilePrefab;
    public Transform launchPoint;
    public float launchForce = 10f;

    private bool playerInRange = false;

    void OnTriggerEnter(Collider playable)
    {
        if (playable.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerInRange = false;
        }
    }

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.F))
        {
            LaunchMissile();
        }
    }

    void LaunchMissile()
    {
        GameObject missile = Instantiate(missilePrefab, launchPoint.position, launchPoint.rotation);
        Rigidbody missileRb = missile.GetComponent<Rigidbody>();

        if (missileRb != null)
        {
            Vector3 launchDirection = launchPoint.forward;

            float randomAngle = Random.Range(-10f, 10f);
            launchDirection = Quaternion.Euler(0f, randomAngle, 0f) * launchDirection;

            missileRb.AddForce(launchDirection * launchForce, ForceMode.Impulse);

            float randomUpwardForce = Random.Range(0.8f, 1.2f);
            missileRb.AddForce(Vector3.up * launchForce * randomUpwardForce, ForceMode.Impulse);
        }
        else
        {
            Debug.LogError("Cannot find the Rigibody");
        }
        Destroy(gameObject, 8f);
    }
}