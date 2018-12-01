using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundSelfDestruct : MonoBehaviour
{
    private CameraHelper _camera;

    // Use this for initialization
    void Start()
    {
        LoadCamera();
    }

    void LoadCamera()
    {
        if (!_camera)
        {
            var camera = GameObject.FindWithTag("MainCamera");
            _camera = camera.GetComponent<CameraHelper>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        LoadCamera();
        if (GetRightBound() < _camera.GetLeftBound())
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }

    public float GetRightBound()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        return transform.position.x + GetWidth();
    }

    public float GetWidth()
    {
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        return renderer.sprite.bounds.extents.x;
    }
}