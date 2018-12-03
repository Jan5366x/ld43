using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public float Angle;
    public float Speed;

    // Update is called once per frame
    void Update()
    {
        Quaternion quat = Quaternion.AngleAxis(Angle, Vector3.forward);
        transform.rotation = quat;
        Vector3 vec = quat * Vector3.right;
        transform.Translate(Time.deltaTime * vec * Speed);
    }
}