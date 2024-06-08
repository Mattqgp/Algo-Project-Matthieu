using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeTrail : MonoBehaviour
{
    public GameObject trail;
    public Transform spawnPos;

    public float spawnInterval = 0.5f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        if (timer > spawnInterval)
        {
            Instantiate(trail, spawnPos.position, Quaternion.identity);

            timer = 0;
        }
    }
}
