using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class EnemyWaves : MonoBehaviour
{
    public GameObject enemy;
    public float spawnOffset = 3;
    public int amount = 1;
    int enemyCount = 0;
    GameObject[] enemies;
    bool enemiesInLevel;
    public float spawnDelay = 1f;
    List<Transform> spawnPoints = new();

    public int level;

    public TextMeshProUGUI counter;

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
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        if (enemies.Length > 0 && enemyCount > 0)
        {
            enemiesInLevel = true;
        }else
        {
            enemiesInLevel = false;
        }

        counter.text = "X " + enemies.Length.ToString();

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (enemiesInLevel == false)
            {
                NextWave();
            }
        }
    }

    public void NextWave()
    {
        if (!enemiesInLevel)
        {
            level++;
            amount = Mathf.RoundToInt(amount * 1.5f);

            foreach (Transform t in spawnPoints)
            {
                StartCoroutine(SpawnEnemies(t.position));
            }
        }
    }

    IEnumerator SpawnEnemies(Vector3 position)
    {

        for (int i = Mathf.FloorToInt(amount / spawnPoints.Count); i > 0; i--)
        {
            yield return new WaitForSeconds(spawnDelay);

            float ranX = Random.Range(0, spawnOffset);
            float ranY = Random.Range(0, spawnOffset);
            float ranZ = Random.Range(0, spawnOffset);
            Instantiate(enemy, position + new Vector3(ranX, ranY, ranZ), transform.rotation);

            enemyCount++;
        }
    }
}
