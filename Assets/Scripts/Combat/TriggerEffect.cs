using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerEffect : MonoBehaviour
{
    private Transform _effect;
    public Sprite PreviewSprite;
    public Color PreviewColor;

    private bool _wasTriggered;

    // Use this for initialization
    void Start()
    {
        _wasTriggered = true;
    }

    // Update is called once per frame

    void Update()
    {
        if (_wasTriggered) return;
        if (Input.GetButtonDown("UseSpecialItem") && _effect)
        {
            _wasTriggered = true;
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
        _wasTriggered = false;
    }
}