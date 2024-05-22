using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{
    GameObject player;
    Vector3 playerPos;

    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    bool canJump;
    public float visionRadius;
    public LayerMask playerLayer;
    public bool seesPlayer;

    public Transform eye;
    public Transform eyeTip;

    public GameObject beam;
    Transform laser;

    public int touchDamage = 10;
    public int beamDamage = 20;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        laser = Instantiate(beam, new Vector3(0, -1000, 0), Quaternion.identity).transform;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z);

        transform.LookAt(playerPos);
        Move();

        Beam();

        Look();
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

        if (collision.collider.CompareTag("Player"))
        {
            Health healthScript = collision.collider.GetComponent<Health>();

            healthScript.TakeDamage(touchDamage);
        }
    }

    void Look()
    {
        Collider[] sights = Physics.OverlapSphere(transform.position, visionRadius, playerLayer);

        for(int i = 0; i < sights.Length; i++)
        {
            if (sights[i].CompareTag("Player"))
            {
                seesPlayer = true; break;
            }
            else
            {
                seesPlayer = false;
            }
        }
    }

    void Beam()
    {
        if (seesPlayer)
        {
            Physics.SphereCast(eyeTip.position, 0.5f, eyeTip.position - eye.position, out RaycastHit hit);

            laser.LookAt(eye.position);
            laser.position = eye.position + ((eyeTip.transform.position - eye.position).normalized * (hit.distance / 2));
            laser.localScale = new Vector3(laser.transform.localScale.x, laser.transform.localScale.y, hit.distance / 2);
        }
        else
        {
            laser.position = new Vector3(0, -1000, 0);
        }
    }
}
