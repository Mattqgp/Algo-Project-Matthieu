using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Boss : MonoBehaviour
{
    #region

    [Header("References")]
    GameObject player;
    Vector3 playerPos;

    public Transform eye;
    public Transform eyeTip;

    public Rigidbody rb;
    public Animator anim;

    public GameObject beam;
    Transform laser;

    [Header("General")]
    public float moveSpeed = 5f;
    public float jumpForce = 15f;
    bool canJump;
    int attack;
    public int touchDamage = 5;

    #region
    [Header("Vision")]
    public float laserVisionRadius;
    public float crushVisionRadius;
    bool laserSeesPlayer;
    bool crushSeesPlayer;
    #endregion

    #region
    [Header("Beam")]
    public int beamDamage = 10;
    bool isBeamAttacking;
    public float beamDamageDelay = 1f;
    #endregion

    #region
    [Header("Crushing")]
    public float jumpHeight;
    public float jumpSpeed;
    public float airTime;
    float timer;
    public float hoverSpeed;
    public float crushSpeed;
    public float knockback;
    bool isCrushing;
    #endregion

    #endregion

    #region
    #region
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

        Attack();

        if (isCrushing)
        {
            laserSeesPlayer = false;
            laser.position = new Vector3(0, -1000, 0);
        }
    }

    private void FixedUpdate()
    {
        Look();
    }
    #endregion

    #region

    void Move()
    {
        transform.position = Vector3.MoveTowards(transform.position, playerPos, moveSpeed * Time.deltaTime);
        Jump();
    }

    void Jump()
    {
        if (canJump)
        {
            anim.SetTrigger("Jump");

            Rigidbody Rb = GetComponent<Rigidbody>();
            Rb.velocity = new Vector3(0, jumpForce, 0);

            canJump = false;
        }
    }

    #endregion

    private void OnCollisionEnter(Collision collision)
    {
        anim.SetTrigger("Spin");

        canJump = true;

        if (collision.collider.CompareTag("Player"))
        {

            Health healthScript = collision.collider.GetComponent<Health>();

            healthScript.TakeDamage(touchDamage);

            GameObject hitObject = collision.gameObject;
            Vector3 knockbackDir = hitObject.transform.position - transform.position;
            Rigidbody plrRb = hitObject.GetComponent<Rigidbody>();

            plrRb.isKinematic = false;
            plrRb.AddForce(new Vector3(knockbackDir.x, 50, knockbackDir.z).normalized * knockback, ForceMode.Impulse);
        }
    }

    void Look()
    {
        Collider[] laserSights = Physics.OverlapSphere(transform.position, laserVisionRadius);
        Collider[] crushSights = Physics.OverlapSphere(transform.position, crushVisionRadius);

        foreach(Collider coll in laserSights)
        {
            if (coll.CompareTag("Player"))
            {
                laserSeesPlayer = true; break;
            }
            else
            {
                laserSeesPlayer = false;
            }
        }

        foreach(Collider coll in crushSights)
        {
            if (coll.CompareTag("Player"))
            {
                crushSeesPlayer = true; break;
            }
            else
            {
                crushSeesPlayer = false;
            }
        }

        if (laserSeesPlayer && !crushSeesPlayer && !isCrushing)
        {
            attack = 1;
        }
        else if ((laserSeesPlayer && crushSeesPlayer) || (!laserSeesPlayer && crushSeesPlayer) && !isCrushing)
        {
            attack = 2;
        }
        else if(!laserSeesPlayer && !crushSeesPlayer && !isCrushing)
        {
            attack = 0;
        }
    }

    #region

    void Attack()
    {
        if (attack == 0)
        {
            return;
        }else if (attack == 1)
        {
            Beam();
        }else if (attack == 2)
        {
            StartCoroutine(Crush());
        }
    }

    #region
    IEnumerator Crush()
    {
        if (!isCrushing && canJump)
        {
            isCrushing = true;

            timer = 0f;

            while (transform.position.y != jumpHeight)
            {
                JumpToTop();
                yield return null;
            }

            while (timer < airTime)
            {
                timer += Time.deltaTime;

                Hover();

                yield return null;
            }

            anim.SetTrigger("Spin");
            yield return new WaitForSeconds(anim.GetCurrentAnimatorStateInfo(anim.GetLayerIndex("Base Layer")).length);

            CrushTarget();

            isCrushing = false;
        }
    }

    void JumpToTop()
    {
        Vector3 targetPos = new(player.transform.position.x, jumpHeight, player.transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, jumpSpeed);
        rb.isKinematic = true;
    }

    void Hover()
    {
        Vector3 targetPos = new(player.transform.position.x, jumpHeight, player.transform.position.y);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, hoverSpeed);
    }

    void CrushTarget()
    {
        rb.isKinematic = false;
        rb.AddForce(Vector3.down * crushSpeed, ForceMode.Impulse);
    }
    #endregion

    #region
    void Beam()
    {
        if (laserSeesPlayer)
        {
            bool laserHit = Physics.SphereCast(eyeTip.position, 0.5f, eyeTip.position - eye.position, out RaycastHit hit);

            laser.LookAt(eye.position);
            laser.position = eye.position + ((eyeTip.transform.position - eye.position).normalized * (hit.distance / 2));
            laser.localScale = new Vector3(laser.transform.localScale.x, laser.transform.localScale.y, hit.distance / 2);

            if (laserHit && hit.collider.CompareTag("Player"))
            {
                StartCoroutine(BeamDamge(hit.collider.gameObject));
            }
        }
        else
        {
            laser.position = new Vector3(0, -1000, 0);
        }
    }

    IEnumerator BeamDamge(GameObject playerObject)
    {
        if (!isBeamAttacking)
        {
            isBeamAttacking = true;

            Health healthScript = playerObject.GetComponent<Health>();

            healthScript.TakeDamage(beamDamage);

            yield return new WaitForSeconds(beamDamageDelay);

            isBeamAttacking = false;
        }
    }
    #endregion

    #endregion

    #endregion
}
