using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public Transform Prefab;

    // Use this for initialization
    void Start()
    {
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
        
        Instantiate(Prefab, player.transform.position + new Vector3(12, 0, 0), Quaternion.identity, transform);
    }
}