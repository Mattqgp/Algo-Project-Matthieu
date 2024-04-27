using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public MeshFilter meshFilter;
    public BoxCollider coll;

    GameObject player;

    public List<Mesh> meshes = new List<Mesh>();
    public List<Vector3> collSize = new List<Vector3>();
    public List<Vector3> collOffset = new List<Vector3>();

    public float speed;

    public int health = 100;

    public int damage = 30;

    public float knockback = 1000f;

    // Start is called before the first frame update
    void Start()
    {
        int randomNum = Random.Range(0, 3);
        meshFilter.mesh = meshes[randomNum];
        coll.center = collOffset[randomNum];
        coll.size = collSize[randomNum];

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {
            Vector3 playerLookAt = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);
            transform.LookAt(playerLookAt);

            transform.position = Vector3.MoveTowards(transform.position, playerLookAt, speed * Time.deltaTime);
        }
    }

    public void TakeDamage(int damage){
        health -= damage;

        if (health <= 0f){
            Die();
        }
    }

    void Die(){
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision other) {
        if (other.gameObject.CompareTag("Player")){
            PlayerMovement player = other.gameObject.GetComponent<PlayerMovement>();

            player.TakeDamage(damage);

            Rigidbody Rb = other.gameObject.GetComponent<Rigidbody>();

            Vector3 knockbackDir = (other.gameObject.transform.position - transform.position) * knockback;
            Rb.AddForce(knockbackDir, ForceMode.Impulse);
        }
    }
}
