using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Psy : MonoBehaviour
{
    public float radius;

    public int damage;

    public GameObject visual;

    bool canDamage = true;

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
                StartCoroutine(DealDamage(coll.gameObject));
            }
        }

        visual.transform.localScale = new Vector3(radius * 2, radius * 2, radius * 2);
    }

    IEnumerator DealDamage(GameObject player)
    {
        if (canDamage)
        {
            canDamage = false;

            Health health = player.GetComponent<Health>();

            health.TakeDamage(damage);

            yield return new WaitForSeconds(3f);

            canDamage = true;
        }
    }
}
