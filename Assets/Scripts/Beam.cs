using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Beam : MonoBehaviour
{
    public GameObject target;
    public GameObject beam;
    Transform laser;

    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        laser = Instantiate(beam, new Vector3(0, -100, 0), Quaternion.identity).transform;
    }

    // Update is called once per frame
    void Update()
    {
        Laser();
        Visuals();
    }

    void Laser()
    {
        Physics.SphereCast(transform.position, 0.5f, target.transform.position - transform.position, out hit);
    }

    void Visuals()
    {
        laser.LookAt(transform.position);
        laser.position = transform.position + ((target.transform.position - transform.position).normalized * (hit.distance / 2));
        laser.localScale = new Vector3(laser.transform.localScale.x, laser.transform.localScale.y, hit.distance / 2);
    }
}