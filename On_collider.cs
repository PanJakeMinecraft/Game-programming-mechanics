using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class On_collider : MonoBehaviour
{
    public float launchForce = 10f;
    public float maxLaunchDistance = 3f;
    public GameObject launchParticlePrefab; 
    private Rigidbody rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.isKinematic = true;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F) && IsPlayerInRange())
        {
            LaunchProjectile();
        }
    }

    bool IsPlayerInRange()
    {
        return Vector3.Distance(transform.position, player.position) <= maxLaunchDistance;
    }

    void LaunchProjectile()
    {
        rb.isKinematic = false;
        rb.AddForce(transform.forward * launchForce, ForceMode.Impulse);

        if (launchParticlePrefab != null)
        {
            GameObject particleSystemObject = Instantiate(launchParticlePrefab, transform.position, Quaternion.identity);
            Destroy(particleSystemObject, 5f);
        }

        Destroy(gameObject, 5f);
    }
}