using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RenderPulse : MonoBehaviour
{
    public float Amount;
    public float DurationWaitMin;
    public float DurationWaitMax;
    public float DurationFlash;
    private float _start;
    private SpriteRenderer _renderer;
    private Color _base;
    private float _durationWait;

    // Use this for initialization
    void Start()
    {
        _start = Time.time;
        _renderer = GetComponent<SpriteRenderer>();
        _base = _renderer.color;
        _durationWait = Random.Range(DurationWaitMin, DurationWaitMax);
    }

    void Update()
    {
        float dt = Time.time - _start;
        float duration = _durationWait + DurationFlash;


        float t;
        if (dt < _durationWait)
        {
            t = 0;
        }
        else
        {
            t = Mathf.Sin((dt - _durationWait) / DurationFlash * Mathf.PI);
        }

        float h, s, v;
        Color.RGBToHSV(_base, out h, out s, out v);
        _renderer.color = Color.HSVToRGB(
            h, 
            Mathf.Clamp01(s * (1 - Amount) + s * Amount * t),
            Mathf.Clamp01(v * (1 - Amount) + v * Amount * t)
        );

        if (dt > duration)
        {
            _start = Time.time;
            _durationWait = Random.Range(DurationWaitMin, DurationWaitMax);
        }
    }
}