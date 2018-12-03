using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RingOfFire : MonoBehaviour
{
    public float Angle;
    public Transform Projectile;

    // Use this for initialization
    void Start()
    {
        for (float angle = 0; angle < 360; angle += Angle)
        {
            var obj = Instantiate(Projectile, transform.position, Quaternion.identity);
            var movement = obj.GetComponent<LinearMovement>();
            if (movement)
            {
                movement.Angle = angle;
            }
            else
            {
                obj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}