using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraHelper : MonoBehaviour
{
    public Bounds OrthographicBounds()
    {
        Camera camera = GetComponent<Camera>();
        float screenAspect = (float) Screen.width / (float) Screen.height;
        float cameraHeight = camera.orthographicSize * 2;
        return new Bounds(
            camera.transform.position,
            new Vector3(cameraHeight * screenAspect, cameraHeight, 0)
        );
    }

    public float GetLeftBound()
    {
        return OrthographicBounds().min.x;
    }

    public float GetRightBound()
    {
        return OrthographicBounds().max.x;
    }

    public float GetTopBound()
    {
        return OrthographicBounds().min.y;
    }


    public float GetBottomBound()
    {
        return OrthographicBounds().max.y;
    }

    public float GetPixelDensity()
    {
        Camera cam = GetComponent<Camera>();
        return cam.pixelWidth / cam.orthographicSize;
    }

    public bool IsInBounds(Vector3 pos)
    {
        var bounds = OrthographicBounds();
        //Why u so stupid Unity
        return bounds.min.x < pos.x && bounds.min.y < pos.y &&
               bounds.max.x > pos.x && bounds.max.y > pos.y;
    }
}