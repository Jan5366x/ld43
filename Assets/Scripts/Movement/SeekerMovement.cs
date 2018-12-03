using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public class SeekerMovement : MonoBehaviour
{
    public float Speed;
    public float Range;
    public float TurningAngle;

    private float lastSeek;
    private float _angle;
    private Transform _target;

    // Use this for initialization
    void Start()
    {
        lastSeek = 0;
        _angle = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float dt = Time.time - lastSeek;
        if (0.2 < dt)
        {
            seekTarget();
            lastSeek = Time.time;
        }


        Vector3 targetPosition;
        if (_target)
        {
            targetPosition = _target.position;
        }
        else
        {
            targetPosition = transform.position + new Vector3(100 * Speed, 0, 0);
        }


        Vector3 dist = targetPosition - transform.position;
        float angle = Mathf.Rad2Deg * Mathf.Atan2(dist.y, dist.x);
        angle = Mathf.DeltaAngle(_angle, angle);
        angle = Mathf.Clamp(angle, -TurningAngle*dt, TurningAngle*dt);
        _angle += angle;


        Quaternion quat = Quaternion.AngleAxis(_angle, Vector3.forward);
        dt = Time.deltaTime;
        dist = Speed * dt * (quat * Vector3.right).normalized;


        Debug.DrawLine(transform.position, transform.position + dist, Color.blue);

        transform.Translate(dist.x, dist.y, 0);
        transform.rotation = quat;
    }

    void seekTarget()
    {
        Destructible[] allEnemies = GameObject.FindObjectsOfType<Destructible>();
        var camera = GameObject.FindWithTag("MainCamera");
        var _camera = camera.GetComponent<CameraHelper>();

        int minIdx = -1;
        float minDist = float.MaxValue;


        for (int idx = 0; idx < allEnemies.Length; idx++)
        {
            var enemy = allEnemies[idx];
            if (enemy.IsPlayer || enemy.IsDead())
            {
                continue;
            }

            Vector3 delta = transform.position - enemy.transform.position;
            float dist = delta.x * delta.x + delta.y * delta.y;

            if (dist > Range * Range)
            {
                continue;
            }

            bool inBounds = _camera.IsInBounds(enemy.transform.position);
            if (!inBounds)
            {
                continue;
            }

            if (dist < minDist)
            {
                minDist = dist;
                minIdx = idx;
            }
        }

        if (minIdx >= 0)
        {
            _target = allEnemies[minIdx].transform;
        }
    }
}