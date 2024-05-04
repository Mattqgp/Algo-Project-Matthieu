using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    public int maxBombs = 10;
    public int cost = 2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            SpawnBomb bombScript = other.gameObject.GetComponent<SpawnBomb>();
            Pickup coinScript = other.gameObject.GetComponent<Pickup>();

            if (bombScript.bombStock < maxBombs && coinScript.points >= cost)
            {
                coinScript.points -= cost;
                bombScript.bombStock += 1;

            }
        }
    }
}
