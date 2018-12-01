using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class UserMovement : MonoBehaviour
{
    public float BaseSpeed;
    public float MaxSpeed;
    public float Acceleration;
    private float _speedX;
    private float _speedY;

    // Use this for initialization
    void Start()
    {
        _speedX = BaseSpeed;
        _speedY = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float dt = Time.deltaTime;

        if (Mathf.Approximately(horizontal, 0))
        {
            _speedX = _speedX < 0 ? _speedX + dt * Acceleration : _speedX - dt * Acceleration;
        }
        else
        {
            _speedX += dt * Acceleration * horizontal;
        }

        if (Mathf.Approximately(vertical, 0))
        {
            _speedY = _speedY < 0 ? _speedY + dt * Acceleration : _speedY - dt * Acceleration;
        }
        else
        {
            _speedY += dt * Acceleration * vertical;
        }

        _speedX = Mathf.Clamp(_speedX, -MaxSpeed, MaxSpeed);
        _speedY = Mathf.Clamp(_speedY, -MaxSpeed, MaxSpeed);

        if (Mathf.Approximately(_speedX, 0))
        {
            _speedX = 0;
        }

        if (Mathf.Approximately(_speedY, 0))
        {
            _speedY = 0;
        }

        Vector3 delta = new Vector3(dt * _speedX, dt * _speedY);
        Vector3 newPos = transform.position + delta;


        var camera = GameObject.FindWithTag("MainCamera");
        var cameraHelper = camera.GetComponent<CameraHelper>();

        float camLeft = cameraHelper.GetLeftBound();
        float spriteLeft = GetLeftBound();
        float camRight = cameraHelper.GetRightBound();
        float spriteRight = GetRightBound();
        float camTop = cameraHelper.GetTopBound();
        float spriteTop = GetTopBound();
        float camBottom = cameraHelper.GetBottomBound();
        float spriteBottom = GetBottomBound();


        if (spriteLeft < camLeft)
        {
            newPos.x = Mathf.Max(newPos.x, camLeft + GetWidth());
            if (_speedX < BaseSpeed)
            {
                _speedX = BaseSpeed;
            }
        }
        else if (spriteRight > camRight)
        {
            newPos.x = Mathf.Min(newPos.x, camRight - GetWidth());
            if (_speedX > BaseSpeed)
            {
                _speedX = BaseSpeed;
            }
        }


        if (spriteTop < camTop)
        {
            newPos.y = Mathf.Max(newPos.y, camTop + GetHeight());
            if (_speedY < 0)
            {
                _speedY = 0;
            }
        }
        else if (spriteBottom > camBottom)
        {
            newPos.y = Mathf.Min(newPos.y, camBottom - GetHeight());
            if (_speedY > 0)
            {
                _speedY = 0;
            }
        }
        
        Debug.DrawLine(new Vector3(camLeft, camTop), new Vector3(camRight, camTop), Color.red);
        Debug.DrawLine(new Vector3(camLeft, camBottom), new Vector3(camRight, camBottom), Color.green);
        Debug.DrawLine(new Vector3(camLeft, spriteTop), new Vector3(camRight, spriteTop), Color.blue);
        Debug.DrawLine(new Vector3(camLeft, spriteBottom), new Vector3(camRight, spriteBottom), Color.magenta);

        Debug.DrawLine(transform.position, newPos, Color.red);
        Debug.DrawRay(transform.position, new Vector3(_speedX, _speedY), Color.green);
        transform.position = newPos;
    }


    public float GetRightBound()
    {
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        return transform.position.x + GetWidth();
    }

    public float GetLeftBound()
    {
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        return transform.position.x - GetWidth();
    }

    public float GetTopBound()
    {
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        return transform.position.y - GetHeight();
    }

    public float GetBottomBound()
    {
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        return transform.position.y + GetHeight();
    }

    public float GetWidth()
    {
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        return renderer.sprite.bounds.extents.x;
    }

    public float GetHeight()
    {
        SpriteRenderer renderer = GetComponentInChildren<SpriteRenderer>();
        return renderer.sprite.bounds.extents.y;
    }
}