using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollower : MonoBehaviour
{
    private GameObject _player;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * _player.GetComponent<UserMovement>().baseSpeed, 0f, 0f);
    }
}