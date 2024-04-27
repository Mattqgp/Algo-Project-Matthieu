using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float jumpForce = 15f;
    float startJump;

    public float timer = 5f;

    PlayerMovement player;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.gameObject.GetComponent<PlayerMovement>();

            startJump = player.jumpForce;

            player.jumpForce = jumpForce;

            StartCoroutine(Destroy(timer));
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player.jumpForce = startJump;
        }
    }

    IEnumerator Destroy(float delay)
    {
        yield return new WaitForSeconds(delay);

        player.jumpForce = startJump;

        Destroy(gameObject);
    }
}
