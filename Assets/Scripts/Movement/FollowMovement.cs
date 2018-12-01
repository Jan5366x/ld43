using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowMovement : MonoBehaviour
{
    public float SpeedX;
    public float SpeedY;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            float playerBottom = player.GetComponent<UserMovement>().GetBottomBound();
            float playerTop = player.GetComponent<UserMovement>().GetTopBound();
            float playerY = (playerBottom + playerTop) / 2;

            float bottom = GetBottomBound();
            float top = GetTopBound();
            float myY = (bottom + top) / 2;

            float deltaY = playerY - myY;

            Debug.DrawRay(new Vector3(myY, GetLeftBound()), new Vector3(deltaY, 0), Color.cyan);

            deltaY = Mathf.Clamp(deltaY, -SpeedY, SpeedY);
            deltaY *= Time.deltaTime;

            float deltaX = SpeedX * Time.deltaTime;

            transform.Translate(new Vector3(deltaX, deltaY));
        }
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