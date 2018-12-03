using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    public void Swap(Transform prefab)
    {
        foreach (var weapon in GetComponentsInChildren<PlayerWeapon>())
        {
            Destroy(weapon.gameObject);
        }

        Instantiate(prefab, transform);
    }
}