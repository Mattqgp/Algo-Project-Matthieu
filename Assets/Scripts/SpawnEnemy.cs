using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemy;

    public float spawnOffset = 3;

    public float spawnDelay = 3f;
    float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= spawnDelay)
        {
            Instantiate(enemy, transform.position + new Vector3(Random.Range(0, spawnOffset), Random.Range(0, spawnOffset), Random.Range(0, spawnOffset)), transform.rotation);
            timer = 0f;
        }
    }
}
