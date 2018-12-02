using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;

public class SwapWeapon : MonoBehaviour
{
    public void Swap(Transform prefab)
    {
        var weapon = GetComponentInChildren<PlayerWeapon>();
        if (weapon)
        {
            Destroy(weapon.gameObject);
        }

        Instantiate(prefab, transform);
    }
}