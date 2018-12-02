using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Experimental.UIElements;

public class PickupInfo : MonoBehaviour
{
    public float SpeedY;
    public float Duration;
    public bool Fade;
    private float _start;
    private static float _lastReset;
    private static float _resetDuration = 3;

    private static int _queueIdx;

    private void Start()
    {
        _start = Time.time;
    }

    private void Update()
    {
        var ddt = Time.time - _lastReset;
        if (ddt > _resetDuration && _queueIdx > 0)
        {
            ResetQueue();
            _lastReset = Time.time;
        }

        var dt = Time.time - _start;
        transform.Translate(0, SpeedY, 0);
        if (Fade)
        {
            foreach (var label in GetComponentsInChildren<TextMeshProUGUI>())
            {
                var color = label.color;
                var a = Mathf.Clamp(1 - dt / Duration, 0, 1);
                Debug.Log("+++++" + a);
                color.a = a;
                label.color = color;
            }
        }

        if (dt > Duration)
        {
            Destroy(gameObject);
        }
    }


    public static Transform Spawner(string text, float delta)
    {
        if (Mathf.Approximately(delta, 0)) return null;

        var hud = GameObject.FindWithTag("HUD");
        if (!hud) return null;

        var hudpanel = hud.transform.Find("HUDPanel");
        if (!hudpanel) return null;

        Transform prefab = Instantiate(Resources.Load<Transform>("Pickups/PickupInfo"), hudpanel.transform);
        prefab.Translate(0f, -30f * _queueIdx, 0f);
        _queueIdx++;
        foreach (var label in prefab.GetComponentsInChildren<TextMeshProUGUI>())
        {
            if (label.name == "Text")
            {
                label.text = text;
                label.color = Color.black;
            }
            else if (label.name == "Delta")
            {
                label.text = (delta > 0 ? "+" : "") + delta;
                label.color = delta > 0 ? Color.green : Color.red;
            }
        }

        return prefab;
    }

    public static void ResetQueue()
    {
        _queueIdx = 0;
    }
}