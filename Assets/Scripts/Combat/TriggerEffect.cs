using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffect : MonoBehaviour
{
    private Transform _effect;
    public Sprite PreviewSprite;
    public Color PreviewColor;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame

    void Update()
    {
        if (Input.GetButtonDown("Fire3") && _effect)
        {
            Instantiate(_effect, transform.position, Quaternion.identity);
            _effect = null;
            PreviewSprite = null;
            PreviewColor = Color.clear;
        }
    }

    public void Store(Transform effect, Sprite sprite, Color color)
    {
        _effect = effect;
        PreviewSprite = sprite;
        PreviewColor = color;
    }
}