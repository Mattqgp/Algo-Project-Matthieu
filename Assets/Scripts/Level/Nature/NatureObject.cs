using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NatureObject : MonoBehaviour
{
    public GameObject[] natureStuff;

    // Start is called before the first frame update
    void Start()
    {
        GameObject ranObject = natureStuff[Random.Range(0, natureStuff.Length)];
        Instantiate(ranObject, gameObject.transform);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
