using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;

    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    bool canJump;
    public float visionRadius;
    public LayerMask playerLayer;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(playerPos);
        Move();
    }

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
        Jump();
    }

    void Jump()
    {
        if (canJump)
        {
            Rigidbody Rb = GetComponent<Rigidbody>();
            Rb.velocity = new Vector3(0, jumpForce, 0);

            canJump = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        canJump = true;
    }
}
