using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DeathScene : MonoBehaviour
{
    private bool _gameOver;

    public void Toggle()
    {
        Time.timeScale = 0.0f;
        GetComponent<Image>().enabled = true;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(true);
        }
    }
}