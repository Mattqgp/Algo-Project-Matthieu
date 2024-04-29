using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickup : MonoBehaviour
{
    public int points = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Touched");

        if (collision.gameObject.CompareTag("Collectable"))
        {
            Debug.Log("Collectable!!!");

            Collectable collectable = collision.GetComponent<Collectable>();
            points += collectable.value;

            Debug.Log("Added " + collectable.value + "To points, Now It's " + points);
        }
    }
}
