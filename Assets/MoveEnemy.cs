using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    public GameObject Player;

    public float Speed;

    private float Health;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 RotateDir = Player.transform.position - transform.position;

        transform.Rotate(0, RotateDir.y, 0);

        transform.position = Vector3.MoveTowards(transform.position, Player.transform.position, Speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Health -= 1;
            collision.gameObject.GetComponent<BulletMove>().hit();
        }
    }
}
