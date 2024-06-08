using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Eat : MonoBehaviour
{
    public Transform mouth;
    public int damage;
    public float radius;

    public float interval = 4f;
    float timer;

    public float nearRadius;
    bool isNearPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        CheckForPlayer();

        timer += Time.deltaTime;

        if (timer >= interval)
        {
            timer = 0f;

            if (isNearPlayer)
            {
                EatPlayer();
            }
        }
    }

    void CheckForPlayer()
    {
        foreach (Collider coll in Physics.OverlapSphere(transform.position, nearRadius))
        {
            if (coll.CompareTag("Player"))
            {
                isNearPlayer = true; break;
            }
            else
            {
                isNearPlayer = false;
            }
        }
    }

    void EatPlayer()
    {
        foreach(Collider coll in Physics.OverlapSphere(mouth.position, radius))
        {
            if (coll.CompareTag("Player"))
            {
                DealDamage(coll.gameObject);
            }
        }
    }

    void DealDamage(GameObject player)
    {
        Health health = player.GetComponent<Health>();

        health.TakeDamage(damage);
    }
}
