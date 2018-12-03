using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdate : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        var text = GetComponent<TextMeshPro>();
        var player = GameObject.FindGameObjectWithTag("Player");
        if (!player) return;
        var score = player.GetComponent<ScoreCounter>();
        if (!score) return;
        if (text)
        {
            text.text = "Score: " + score.Score;
        }
    }
}