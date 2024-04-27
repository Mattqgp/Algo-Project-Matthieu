using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float speed = 15f;
    float startSpeed;

    public float timer = 5f;

    PlayerMovement player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerMovement>();

            startSpeed = player.speed;

            player.speed = speed;

            StartCoroutine(Destroy(timer));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerMovement>();

            player.speed = startSpeed;
        }
    }

    IEnumerator Destroy(float delay)
    {
        yield return new WaitForSeconds(delay);

        player.speed = startSpeed;

        Destroy(gameObject);
    }
}
