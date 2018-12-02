using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;
using UnityEngine.Serialization;

public class PickupItem : MonoBehaviour
{
    public int ShieldDelta;
    public int PointsDelta;
    public int ArmorDelta;
    public int EnergyDelta;
    public Transform Item;

    void OnTriggerEnter2D(Collider2D other)
    {
        var d = other.GetComponent<Destructible>();
        if (!d) return;

        if (!d.IsDead() && d.IsPlayer)
        {
            d.CurrentShield = Mathf.Clamp(d.CurrentShield + ShieldDelta, 0, d.MaxShield);
            d.CurrentArmor = Mathf.Clamp(d.CurrentArmor + ArmorDelta, 0, d.MaxArmor);
        }

        var w = other.GetComponentInChildren<PlayerWeapon>();
        if (!w) return;

        w.CurrentEnergy = Mathf.Clamp(w.CurrentEnergy + EnergyDelta, 0, w.MaxEnergy);

        Destroy(gameObject);

        if (!Item) return;
        
        var swap = other.GetComponentInChildren<SwapWeapon>();
        if (swap)
        {
            swap.Swap(Item);
        }
    }
}