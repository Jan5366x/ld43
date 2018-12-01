using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSelfDestruct : MonoBehaviour
{
    private CameraHelper _camera;

    // Use this for initialization
    void Start()
    {
        var camera = GameObject.FindWithTag("MainCamera");
        _camera = camera.GetComponent<CameraHelper>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("+++" + GetRightBound() + " " + _camera.GetLeftBound());
        if (GetRightBound() < _camera.GetLeftBound())
        {
            Debug.Log("+----Bye");
            Destroy(this);
        }
    }

    public float GetRightBound()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        return transform.position.x +
               transform.localScale.x * renderer.sprite.texture.width / _camera.GetPixelDensity();
    }
}