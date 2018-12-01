using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    public Transform Prefab;
    private List<Transform> _instances;
    private GameObject _player;
    private GameObject _camera;

    // Use this for initialization
    void Start()
    {
        _player = GameObject.FindWithTag("Player");
        _camera = GameObject.FindWithTag("MainCamera");

        _camera.GetComponent<Camera>();

        _instances = new List<Transform>();


        var offset = _camera.transform.position.x - 2 * _camera.GetComponent<Camera>().orthographicSize;
        var rightSide = _camera.transform.position.x + 2 * _camera.GetComponent<Camera>().orthographicSize;
        while (true)
        {
            Transform inst = Instantiate(Prefab, new Vector3(offset, 0), Quaternion.identity, transform);
            float width = inst.localScale.x;
            _instances.Add(inst);
            offset += width;
            if (offset > rightSide)
            {
                break;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }
}