using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Enemy") && !other.CompareTag("Bullet"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
        }
        
        if (other.CompareTag("Player"))
        {
            Health health = other.GetComponent<Health>();
            health.TakeDamage(damage);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Enemy") || !other.CompareTag("Bullet"))
        {
            Rigidbody rb = GetComponent<Rigidbody>();
            rb.useGravity = true;
        }
    }
}
