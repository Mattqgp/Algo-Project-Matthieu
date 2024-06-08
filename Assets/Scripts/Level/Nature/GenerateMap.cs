using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateMap : MonoBehaviour
{
    public GameObject natureObject;
    public int amount = 50;
    public bool randomAmount;

    // Start is called before the first frame update
    void Start()
    {
        if (randomAmount)
        {
            amount = Random.Range(40, 70);
        }

        for(int i = 0; i < amount; i++)
        {
            float ranX = Random.Range(-35, 35);
            float ranZ = Random.Range(-35, 35);
            Vector3 ranPos = new Vector3(ranX, 0, ranZ);

            Instantiate(natureObject, ranPos, Quaternion.identity);
        }
    }
}
