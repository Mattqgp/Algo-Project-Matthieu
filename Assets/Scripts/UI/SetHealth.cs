using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetHealth : MonoBehaviour
{
    [SerializeField] Slider healthBar;
    Health healthScript;
    int health;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        healthScript = player.GetComponent<Health>();
    }

    // Update is called once per frame
    void Update()
    {
        health = healthScript.health;

        healthBar.value = health;
    }
}
