using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtPlayer : MonoBehaviour
{
    Transform player;

    public bool rotateTowards;
    public float rotateSpeed;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (!rotateTowards)
        {
            transform.LookAt(player);
        }
        else
        {
            Vector3 targetRot = player.transform.position - transform.position;
            transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.LookRotation(targetRot), rotateSpeed * Time.deltaTime);
        }
    }
}
