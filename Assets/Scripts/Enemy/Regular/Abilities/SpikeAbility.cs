using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeAbility : MonoBehaviour
{
    public GameObject spike;
    public Transform origin;

    public int amount = 10;
    public float force = 10f;
    public float distance = 1f;
    float lifeTime = 0.5f;

    public float interval = 1f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        lifeTime = distance / (force / 5);

        if (timer >= interval)
        {
            timer = 0f;
            Eject();
        }
    }

    void Eject()
    {
        for(int i = 0; i < amount; i++)
        {
            GameObject spikeClone = Instantiate(spike, origin.position, Random.rotation);
            Rigidbody rb = spikeClone.GetComponent<Rigidbody>();

            rb.AddForce(spikeClone.transform.forward.normalized * force, ForceMode.Impulse);

            Destroy(spikeClone, lifeTime);
        }
    }
}
