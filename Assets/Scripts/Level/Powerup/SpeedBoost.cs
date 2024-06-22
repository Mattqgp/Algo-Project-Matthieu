using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : MonoBehaviour
{
    public float speed = 15f;
    float startSpeed;

    PlayerMovement player;

    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            GameObject.FindGameObjectWithTag("AudioManager").GetComponent<Sound>().Play(gameObject, 9);

            player = other.GetComponent<PlayerMovement>();

            startSpeed = player.speed;

            player.speed = speed;

            StartCoroutine(Destroy());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerMovement>();

            player.speed = startSpeed;
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(duration);

        player.speed = startSpeed;

        Destroy(gameObject);
    }
}
