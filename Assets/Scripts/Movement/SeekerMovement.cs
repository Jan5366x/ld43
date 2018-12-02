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
        float dt = lastSeek - Time.time;
        if (!_target)
        {
            if (1 > dt && dt < 5)
            {
                seekTarget();
                lastSeek = Time.time;
            }
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
        float dist;
        bool inBounds;
        int idx = 0;

        foreach (var enemy in allEnemies)
        {
            if (enemy.IsPlayer || enemy.IsDead())
            {
                continue;
            }

            dist = Mathf.Abs(Vector3.Distance(transform.position, enemy.transform.position));

            if (dist > Range)
            {
                continue;
            }

            inBounds = _camera.IsInBounds(enemy.transform.position);
            if (!inBounds)
            {
                continue;
            }

            if (dist < minDist)
            {
                minDist = dist;
                minIdx = idx;
            }

            idx++;
        }

        if (minIdx >= 0)
        {
            _target = allEnemies[minIdx].transform;
        }
    }
}