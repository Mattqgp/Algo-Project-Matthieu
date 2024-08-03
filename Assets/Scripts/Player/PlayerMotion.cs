using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        animator.SetFloat("VelX", Input.GetAxis("Horizontal"), 0.1f, Time.deltaTime);
        animator.SetFloat("VelY", Input.GetAxis("Vertical"), 0.1f, Time.deltaTime);
    }
}
