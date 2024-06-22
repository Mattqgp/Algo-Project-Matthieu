using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    public GameObject explosion;
    public float explosionRadius = 5f;
    public int damage = 100;
    public float explosionDelay = 1f;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("Explode", explosionDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void Explode()
    {
        Instantiate(explosion, transform.position, transform.rotation);

        Collider[] enemiesHit = Physics.OverlapSphere(transform.position, explosionRadius);

        foreach (Collider coll in enemiesHit)
        {
            if (coll.gameObject.CompareTag("Enemy"))
            {
                Health health = coll.GetComponent<Health>();
                health.TakeDamage(damage);
            }
        }
        
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Sound>().Play(gameObject, 8);
    }
}
