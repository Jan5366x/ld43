﻿using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform Prefab;
    private GameObject _player;
    private CameraHelper _camera;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        
        var camera = GameObject.FindWithTag("MainCamera");
        _camera = camera.GetComponent<CameraHelper>();

        var offset = _camera.GetLeftBound();
        var rightSide = _camera.GetRightBound();
        while (true)
        {
            Transform inst = Spawn(offset);
            SpriteRenderer renderer = inst.GetComponent<SpriteRenderer>();
            float width = inst.localScale.x * renderer.sprite.texture.width / _camera.GetPixelDensity();

            offset += width;
            if (offset > rightSide)
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float maxRight = GetComponentsInChildren<BackgroundSelfDestruct>().Max(component => component.GetRightBound());
        
        if (maxRight < _camera.GetRightBound())
        {
            Spawn(maxRight);
        }
    }

    private Transform Spawn(float offset)
    {
        return Instantiate(Prefab, new Vector3(offset, 0), Quaternion.identity, transform);
    }
}