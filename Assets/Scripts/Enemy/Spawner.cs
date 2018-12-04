using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Combat;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform PlayerPrefab;
    public Wave[] Waves;
    public PickupWave[] Items;
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

        foreach (var item in Items)
        {
            StartCoroutine("SpawnPickups", item);
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    IEnumerator SpawnPickups(PickupWave item)
    {
        LoadCamera();

        while (true)
        {
            yield return new WaitForSeconds(Random.Range(item.FrequencyMin, item.FrequencyMax));
            SpawnAtBouds(_camera.OrthographicBounds(), item.Prefab);
        }
    }

    IEnumerator SpawnDelayed()
    {
        for (int cycle = 0;; cycle++)
        {
            LoadCamera();
            foreach (var wave in Waves)
            {
                if (wave.spawnWhenEmpty)
                {
                    while (FindObjectsOfType<EnemyWeapon>().Length > 1)
                    {
                        yield return new WaitForSeconds(1);
                    }
                }

                yield return new WaitForSeconds(wave.delay);
                Bounds bounds = _camera.OrthographicBounds();

                float multiplier = Mathf.Clamp(Mathf.Pow(1.5f, cycle), 0, 3);

                foreach (var waveEntry in wave.enemies)
                {
                    int minCnt = (int) Mathf.Min(waveEntry.MinCount * multiplier, 5);
                    int maxCnt = (int) Mathf.Min(waveEntry.MaxCount * multiplier, 10);
                    int cnt = Random.Range(minCnt, maxCnt);
                    for (int i = 0; i < cnt; i++)
                    {
                        SpawnAtBouds(bounds, waveEntry.enemy);
                    }
                }
            }
        }
    }

    void SpawnAtBouds(Bounds bounds, Transform prefab)
    {
        float spawnX = Random.Range(bounds.max.x, bounds.max.x + bounds.extents.x * 2f);

        float maxY = bounds.max.y - 0.2f * bounds.extents.y;
        float minY = bounds.min.y + 0.2f * bounds.extents.y;
        float spawnY = Random.Range(minY, maxY);
        Instantiate(prefab, new Vector3(spawnX, spawnY), Quaternion.identity);
    }
}