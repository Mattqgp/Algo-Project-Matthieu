using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psy : MonoBehaviour
{
    public float radius;

    public int damage;

    public GameObject visual;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach(Collider coll in Physics.OverlapSphere(transform.position, radius))
        {
            if (coll.CompareTag("Player"))
            {
                Health health = coll.GetComponent<Health>();

                health.TakeDamage(damage);
            }
        }

        visual.transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
    }
}
