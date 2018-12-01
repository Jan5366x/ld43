using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    public float GetLeftBound()
    {
        return transform.position.x - 2 * GetComponent<Camera>().orthographicSize;
    }

    public float GetRightBound()
    {
        return transform.position.x + 2 * GetComponent<Camera>().orthographicSize;
    }

    public float GetPixelDensity()
    {
        Camera cam = GetComponent<Camera>();
        return cam.pixelWidth / cam.orthographicSize;
    }
}