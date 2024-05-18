using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SetBoost : MonoBehaviour
{
    [SerializeField] Image arrow; 

    PlayerMovement playerScript;

    string activeBoost;
    Color boostColor;

    public string[] boosts;
    public Color[] color;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerScript.speed > 10)
        {
            activeBoost = boosts[0];
            boostColor = color[0];
        }
        else if (playerScript.jumpForce > 10)
        {
            activeBoost = boosts[1];
            boostColor = color[1];
        }
        else
        {
            activeBoost = null;
            boostColor = new Vector4(0, 0, 0, 0);
        }

        arrow.color = boostColor;
    }
}
