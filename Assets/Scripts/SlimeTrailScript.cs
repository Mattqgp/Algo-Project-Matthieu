using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeTrailScript : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Trigger");

        if (collision.CompareTag("Player"))
        {
            Debug.Log("Player");

            Health health = collision.GetComponent<Health>();

            health.TakeDamage(damage);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collide");

        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player");
            Health health = collision.gameObject.GetComponent<Health>();

            health.TakeDamage(damage);
        }
    }
}
