using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfFire : MonoBehaviour
{
    public float Angle = 5;
    public float Distance = 3;
    public Transform Projectile;

    // Use this for initialization
    void Start()
    {
        for (float angle = 0; angle < 360; angle += Angle)
        {
            var quat = Quaternion.AngleAxis(angle, Vector3.forward);
            var pos = transform.position + Distance * (quat * Vector3.right);
            var obj = Instantiate(Projectile, pos, Quaternion.identity);
            var movement = obj.GetComponent<LinearMovement>();
            if (movement)
            {
                movement.Angle = angle;
            }
            else
            {
                obj.transform.rotation = quat;
            }
        }
    }
}