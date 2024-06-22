using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBomb : MonoBehaviour
{
    public int bombStock = 0;

    public GameObject bomb;

    public float throwDistance;

    public GameObject playerCamera;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1) && bombStock > 0)
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Sound>().Play(gameObject, 7);

            GameObject bombClone = Instantiate(bomb, playerCamera.transform.position + (transform.forward * 2), playerCamera.transform.rotation);
            bombStock -= 1;
            Rigidbody bombRb = bombClone.GetComponent<Rigidbody>();
            bombRb.AddForce((bombClone.transform.position - playerCamera.transform.position) * throwDistance, ForceMode.Impulse);
        }
    }
}
