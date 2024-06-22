using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDeathCutScene : MonoBehaviour
{
    //To disable
    PlayerMovement pMove;
    SpawnBullets pBullet;
    SpawnBomb pBomb;
    EnemyWaves eWave;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pMove = player.GetComponent<PlayerMovement>();
        pBullet = player.GetComponent<SpawnBullets>();
        pBomb = player.GetComponent<SpawnBomb>();
        eWave = GameObject.FindGameObjectWithTag("WavesManager").GetComponent<EnemyWaves>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartCutscene()
    {
        pMove.enabled = false;
        pBullet.enabled = false;
        pBomb.enabled = false;
        eWave.enabled = false;
    }
}
