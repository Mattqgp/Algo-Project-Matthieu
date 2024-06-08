using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SlimeTrailScript : MonoBehaviour
{
    public int damage = 10;

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Player"))
        {
            Health health = collision.GetComponent<Health>();

            health.TakeDamage(damage);
        }
    }
}
