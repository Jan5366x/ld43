using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform PlayerPrefab;
    public Wave[] Waves;
    private CameraHelper _camera;


    void LoadCamera()
    {
        if (!_camera)
        {
            var camera = GameObject.FindWithTag("MainCamera");
            _camera = camera.GetComponent<CameraHelper>();
        }
    }

    // Use this for initialization
    void Start()
    {
        Instantiate(PlayerPrefab, transform);
        StartCoroutine("SpawnDelayed");
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnDelayed()
    {
        LoadCamera();

        List<Wave> waves = Waves.OrderBy(wave => wave.delay).ToList();
        float delay = 0;
        foreach (var wave in waves)
        {
            yield return new WaitForSeconds(wave.delay - delay);
            delay = wave.delay;
            Bounds bounds = _camera.OrthographicBounds();

            foreach (var waveEntry in wave.enemies)
            {
                int cnt = Random.Range(waveEntry.MinCount, waveEntry.MaxCount);
                for (int i = 0; i < cnt; i++)
                {
                    float spawnX = Random.Range(bounds.max.x, bounds.max.x + bounds.extents.x * 2f);
                    float spawnY = Random.Range(bounds.min.y, bounds.max.y);
                    Instantiate(waveEntry.enemy, new Vector3(spawnX, spawnY), Quaternion.identity);
                }
            }
        }
    }
}