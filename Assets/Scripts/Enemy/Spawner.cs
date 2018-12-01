using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform PlayerPrefab;
    public Transform EnemyPrefab;

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
        yield return new WaitForSeconds(1);
        GameObject player = GameObject.FindWithTag("Player");
        if (player)
        {
            Instantiate(EnemyPrefab, player.transform.position + new Vector3(12, 0, 0), Quaternion.identity, transform);
        }
    }
}