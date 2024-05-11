using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetBombs : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI counter;
    SpawnBomb bombScript;
    int bombs;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        bombScript = player.GetComponent<SpawnBomb>();
    }

    // Update is called once per frame
    void Update()
    {
        bombs = bombScript.bombStock;

        counter.text = "X " + bombs;
    }
}
