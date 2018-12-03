using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

public class BackgroundScroller : MonoBehaviour
{
    public Transform Prefab;
    public float Multiplier;

    private GameObject _player;
    private CameraHelper _camera;

    // Use this for initialization
    void Start()
    {
        var camera = GameObject.FindWithTag("MainCamera");
        _camera = camera.GetComponent<CameraHelper>();

        var offset = _camera.GetLeftBound();
        var rightSide = _camera.GetRightBound();
        while (true)
        {
            Transform inst = Spawn(offset);
            float width = inst.GetComponent<BackgroundSelfDestruct>().GetWidth();

            offset += 2 * width;
            if (offset > rightSide)
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        float maxRight = GetComponentsInChildren<BackgroundSelfDestruct>().Max(component => component.GetRightBound());
        float camRight = _camera.GetRightBound();

        if (maxRight <= camRight)
        {
            Spawn(maxRight);
        }

        if (Multiplier > 0)
        {
            float baseSpeed = 5;
            _player = GameObject.FindWithTag("Player");
            if (_player)
            {
                var userMovement = _player.GetComponent<UserMovement>();
                baseSpeed = userMovement.BaseSpeed;
            }

            transform.Translate(-Multiplier * baseSpeed, 0, 0);
        }
    }

    private Transform Spawn(float offset)
    {
        Transform inst = Instantiate(Prefab, new Vector3(offset, 0), Quaternion.identity, transform);
        float width = inst.GetComponent<BackgroundSelfDestruct>().GetWidth();
        inst.position = new Vector3(inst.position.x + width, inst.position.y, inst.position.z);
        return inst;
    }
}