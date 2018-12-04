using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    private int _score;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            var score = player.GetComponent<ScoreCounter>();
            if (score)
            {
                _score = score.Score;
            }
        }

        var texts = GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var text in texts)
        {
            if (text.name == "Score")
            {
                text.text = "Score: " + _score;
            }
        }
    }
}