using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public float speed = 5f;
    public float runSpeed = 9f;
    float targetMovingSpeed;
    public bool canRun = true;
    public bool isRunning;
    public KeyCode runningKey = KeyCode.LeftShift;

    Rigidbody playerRigidbody;

    private void Awake()
    {
        playerRigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (canRun && Input.GetKey(runningKey))
        {
            isRunning = true;
        }
        else
        {
            isRunning = false;
        }

        if (isRunning)
        {
            targetMovingSpeed = runSpeed;
        }
        else
        {
            targetMovingSpeed = speed;
        }

        playerRigidbody.velocity = transform.rotation * 
            new Vector3(Input.GetAxis("Horizontal"), playerRigidbody.velocity.y, Input.GetAxis("Vertical") * targetMovingSpeed);

        transform.Rotate(Vector3.up * Input.GetAxis("Horizontal") * (100f * Time.deltaTime), Space.Self);
    }
}
