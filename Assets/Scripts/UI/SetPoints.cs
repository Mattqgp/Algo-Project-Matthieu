using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SetPoints : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Text;
    Pickup pointsScript;
    int points;

    // Start is called before the first frame update
    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        pointsScript = player.GetComponent<Pickup>();
    }

    // Update is called once per frame
    void Update()
    {
        points = pointsScript.points;

        Text.text = points.ToString();
    }
}
