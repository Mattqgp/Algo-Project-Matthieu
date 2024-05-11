using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaves : MonoBehaviour
{
    public GameObject enemy;

    public float spawnOffset = 3;

    public int amount = 5;

    public int level;

    int enemyCount = 0;

    bool enemiesInLevel;

    float delay = 10f;

    List<Transform> spawnPoints = new();

    // Start is called before the first frame update
    void Start()
    {
        foreach(GameObject gO in GameObject.FindGameObjectsWithTag("EnemySpawner"))
        {
            spawnPoints.Add(gO.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("Enemy").Length > 0 && enemyCount < amount)
        {
            enemiesInLevel = true;
        }else
        {
            enemiesInLevel = false;
        }
    }

    public void NextWave()
    {
        Debug.Log(enemiesInLevel);

        if (!enemiesInLevel)
        {
            level++;
            amount *= 2;

            foreach (Transform t in spawnPoints)
            {
                SpawnEnemies(t.position);
            }
        }
    }

    void SpawnEnemies(Vector3 position)
    {
        for (int i = amount; i > 0; i--)
        {
            float ranX = Random.Range(0, spawnOffset);
            float ranY = Random.Range(0, spawnOffset);
            float ranZ = Random.Range(0, spawnOffset);
            Instantiate(enemy, position + new Vector3(ranX, ranY, ranZ), transform.rotation);

            enemyCount++;
        }
    }
}
