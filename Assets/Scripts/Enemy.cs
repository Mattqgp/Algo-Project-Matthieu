using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public MeshFilter meshFilter;
    public BoxCollider coll;

    GameObject player;

    public List<Mesh> meshes = new List<Mesh>();
    public List<Vector3> collSize = new List<Vector3>();
    public List<Vector3> collOffset = new List<Vector3>();

    // Start is called before the first frame update
    void Start()
    {
        int randomNum = Random.Range(0, meshes.Count);
        //meshFilter.mesh = meshes[randomNum];
        //coll.center = collOffset[randomNum];
        //coll.size = collSize[randomNum];

        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 lookDir = player.transform.position - transform.position;
        transform.rotation = Quaternion.Euler(lookDir);
    }
}
