using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody Rb;
    public float speed = 2f;
    public float rotateSpeed = 30f;

    // Start is called before the first frame update
    void Start()
    {
        Rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        transform.Translate(horizontal * speed *Time.deltaTime, 0, vertical * speed * Time.deltaTime);

        Vector3 RotateDir = new Vector3(0, rotateSpeed, 0);
        if (Input.GetAxis("Mouse X") < 0)
        {
            transform.Rotate(-RotateDir);
        }else if (Input.GetAxis("Mouse X") > 0)
        {
            transform.Rotate(RotateDir);
        }
    }
}
