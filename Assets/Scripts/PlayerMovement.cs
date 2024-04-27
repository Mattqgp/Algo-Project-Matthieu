using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody Rb;
    public GameObject Camera;

    public float speed = 2f;
    public float rotateSpeed = 1f;
    public float jumpForce = 5f;

    public int health = 100;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(horizontal * speed * Time.deltaTime, 0, vertical * speed * Time.deltaTime);

        Vector3 XRotateDir = new Vector3(0, rotateSpeed, 0);
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(-XRotateDir);
        }
        else if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(XRotateDir);
        }

        Vector3 YRotateDir = new Vector3(rotateSpeed, 0, 0);
        if (Input.GetAxis("Mouse Y") < 0)
        {
            Camera.transform.Rotate(YRotateDir);
        }
        else if (Input.GetAxis("Mouse Y") > 0)
        {
            Camera.transform.Rotate(-YRotateDir);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Rb.velocity = new Vector3(Rb.velocity.x, jumpForce, Rb.velocity.z);
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0f)
        {
            Die();
        }
    }

    void Die()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
