using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public class SeekerMovement : MonoBehaviour
{
    public float SpeedX;
    public float SpeedY;
    public float Range;

    private float lastSeek;
    private Transform _target;

    // Use this for initialization
    void Start()
    {
        lastSeek = 0;
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
            targetPosition = transform.position + new Vector3(100 * SpeedX, 0, 0);
        }


        dt = Time.deltaTime;
        Vector3 dist = targetPosition - transform.position;
        float sX = dt * SpeedX;
        float sY = dt * SpeedY;
        float distX = Mathf.Clamp(dist.x, -sX, sX);
        float distY = Mathf.Clamp(dist.y, -sY, sY);

        transform.Translate(distX, distY, 0);
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