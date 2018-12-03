using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinearMovement : MonoBehaviour
{
    public float Angle;
    public float Speed;

    private void Start()
    {
        Quaternion quat = Quaternion.AngleAxis(Angle, Vector3.forward);
        transform.rotation = quat;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Time.deltaTime * Vector3.right * Speed);
    }
}