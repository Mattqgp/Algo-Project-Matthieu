using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemShop : MonoBehaviour
{
    GameObject player;
    Pickup coinScript;

    public int health;
    public float speed;
    public float jumpForce;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        coinScript = player.GetComponent<Pickup>();
    }

    public void BuyBomb(int cost)
    {
        SpawnBomb bombScript = player.GetComponent<SpawnBomb>();

        if (coinScript.points >= cost)
        {
            coinScript.points -= cost;
            bombScript.bombStock += 1;

        }
    }

    public void BuyHealth(int cost)
    {
        Health healthScript = player.GetComponent<Health>();

        if (coinScript.points >= cost)
        {
            coinScript.points -= cost;
            healthScript.health += health;
        }
    }

    public void BuySpeed(int cost)
    {
        PlayerMovement moveScript = player.GetComponent<PlayerMovement>();

        if (coinScript.points >= cost)
        {
            coinScript.points -= cost;
            moveScript.speed += speed;
        }
    }

    public void BuyJump(int cost)
    {
        PlayerMovement moveScript = player.GetComponent<PlayerMovement>();

        if (coinScript.points >= cost)
        {
            coinScript.points -= cost;
            moveScript.jumpForce += jumpForce;
        }
    }
}
