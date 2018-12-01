﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserMovement : MonoBehaviour
{
    public float baseSpeed;
    public float speed;

    // Use this for initialization
    void Start()
    {
        speed = baseSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 delta = new Vector3();
        delta.x = Time.deltaTime * speed * Input.GetAxis("Horizontal");
        delta.y = Time.deltaTime * speed * Input.GetAxis("Vertical");
        transform.Translate(delta);

        var camera = GameObject.FindWithTag("MainCamera");
        var cameraHelper = camera.GetComponent<CameraHelper>();

        float left = cameraHelper.GetLeftBound();

        if (transform.position.x < left)
        {
            transform.position = new Vector3(left, transform.position.y, transform.position.z);
        }
    }
}