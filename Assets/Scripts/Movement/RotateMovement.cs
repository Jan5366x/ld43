using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMovement : MonoBehaviour
{
    public float AngularVelocity = 5;
    private float _angle = 0;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        _angle += AngularVelocity * Time.deltaTime;
        transform.rotation = Quaternion.AngleAxis(_angle, Vector3.forward);
    }
}