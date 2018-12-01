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
        if (GetRightBound() < _camera.GetLeftBound())
        {
            Destroy(gameObject);
            Destroy(this);
        }
    }

    public float GetRightBound()
    {
        return transform.position.x + GetWidth();
    }

    public float GetWidth()
    {
        LoadCamera();
        SpriteRenderer renderer = GetComponent<SpriteRenderer>();
        if (renderer)
        {
            return transform.localScale.x * renderer.sprite.texture.width / renderer.sprite.pixelsPerUnit;
        }

        return 0;
    }
}