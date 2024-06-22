using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject player;

    public float speed;

    public int damage = 30;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 playerLookAt = new(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(playerLookAt);

            transform.position = Vector3.MoveTowards(transform.position, playerLookAt, speed * Time.deltaTime);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Sound>().Play(gameObject, 11);

            Health health = other.gameObject.GetComponent<Health>();
            health.TakeDamage(damage);
        }
    }
}
