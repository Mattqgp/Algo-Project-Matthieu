using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animate : MonoBehaviour
{
    public Animator animator;

    public Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");
        float horizontal = Input.GetAxis("Horizontal");

        bool moving = vertical != 0 || horizontal != 0;

        animator.SetBool("Moving", moving);
    }

    private void OnCollisionEnter(Collision collision)
    {
        animator.SetBool("Grounded", true);
    }

    private void OnCollisionExit(Collision collision)
    {
        animator.SetBool("Grounded", false);
    }
}
