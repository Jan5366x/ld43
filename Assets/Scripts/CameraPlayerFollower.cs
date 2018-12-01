using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPlayerFollower : MonoBehaviour
{
    private GameObject _player;

    // Use this for initialization
    void Start()
    {
        LoadPlayer();
    }

    private void LoadPlayer()
    {
        if (!_player)
        {
            _player = GameObject.FindWithTag("Player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        LoadPlayer();
        if (_player)
        {
            UserMovement userMovement = _player.GetComponent<UserMovement>();
            if (userMovement)
            {
                transform.Translate(Time.deltaTime * userMovement.BaseSpeed, 0f, 0f);
            }
        }
    }
}