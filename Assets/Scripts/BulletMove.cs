using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMove : MonoBehaviour
{
    public float Speed = 5f;

    public int damage = 50;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(gameObject, 5);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(0, 0, Speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Health health = other.GetComponent<Health>();
            health.TakeDamage(damage);
        }

        if (other.CompareTag("Boss"))
        {
            Health health = other.GetComponent<Health>();
            health.TakeDamage(2);
        }

        if (other.CompareTag("BossEye"))
        {
            Health health = other.GetComponentInParent<Health>();
            health.TakeDamage(20);
        }

        Destroy(gameObject);
    }
}
