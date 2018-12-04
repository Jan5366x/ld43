using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PauseScene : MonoBehaviour
{
    private bool _paused = false;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Toggle();
        }
        else
        {

//            if (_paused == false && Input.GetAxis("Cancel") > 0.8)
//            {
//                Toggle();
//            }
//            else if (_paused && Input.GetAxis("Cancel") < 0.2)
//            {
//                Toggle();
//            }
        }
    }

    public void Toggle()
    {
        _paused = !_paused;
        Time.timeScale = _paused ? 1f : 0f;
        GetComponent<Image>().enabled = !_paused;
        for (int i = 0; i < transform.childCount; i++)
        {
            transform.GetChild(i).gameObject.SetActive(!_paused);
        }  
    }
}