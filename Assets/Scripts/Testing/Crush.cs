using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crush : MonoBehaviour
{
    public Rigidbody rb;

    public Transform target;
    public float jumpHeight;
    public float jumpSpeed;

    public float airTime;
    float timer;
    public float hoverSpeed;

    public float crushSpeed;

    public float knockback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        timer = 0f;

        Vector3 targetPos = new(target.position.x, jumpHeight, target.position.y);

        while (transform.position.y != jumpHeight)
        {
            Jump();
            yield return null;
        }

        while (timer < airTime)
        {
            timer += Time.deltaTime;

            Hover();

            yield return null;
        }

        CrushTarget();
    }

    void Jump()
    {
        Vector3 targetPos = new(target.position.x, jumpHeight, target.position.y);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, jumpSpeed);
        rb.isKinematic = true;
    }

    void Hover()
    {
        Vector3 targetPos = new(target.position.x, jumpHeight, target.position.y);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, hoverSpeed);
    }

    void CrushTarget()
    {
        Vector3 endPoint = new Vector3(transform.position.x, 1, transform.position.z);
        rb.isKinematic = false;
        rb.AddForce(Vector3.down * crushSpeed, ForceMode.Impulse);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            GameObject hitObject = collision.gameObject;
            Vector3 knockbackDir = hitObject.transform.position - transform.position;
            Rigidbody plrRb = hitObject.GetComponent<Rigidbody>();

            plrRb.isKinematic = false;
            plrRb.AddForce(new Vector3(knockbackDir.x, 0, knockbackDir.z).normalized * knockback, ForceMode.Impulse);
        }
    }
}
