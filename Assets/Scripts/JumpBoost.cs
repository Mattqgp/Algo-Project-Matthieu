using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpBoost : MonoBehaviour
{
    public float jumpForce = 15f;
    float startJump;

    PlayerMovement player;

    public float duration = 5f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerMovement>();

            startJump = player.jumpForce;

            player.jumpForce = jumpForce;

            StartCoroutine(Destroy());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            player = other.GetComponent<PlayerMovement>();

            player.jumpForce = startJump;
        }
    }

    IEnumerator Destroy()
    {
        yield return new WaitForSeconds(duration);

        player.jumpForce = startJump;

        Destroy(gameObject);
    }
}