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
        if (!isPlayer(other)) return;

        updateWeapon(other);
        updateShields(other);
        updateArmor(other);
        updateEnergy(other);
        updateScore(other);

        Destroy(gameObject);
    }

    private void updateWeapon(Component other)
    {
        if (!Item) return;

        var swap = other.GetComponentInChildren<SwapWeapon>();
        if (swap)
        {
            swap.Swap(Item);
        }
    }

    private void updateShields(Component other)
    {
        var destructible = other.GetComponent<Destructible>();
        destructible.CurrentShield = Mathf.Clamp(destructible.CurrentShield + ShieldDelta, 0, destructible.MaxShield);
    }

    private void updateArmor(Component other)
    {
        var destructible = other.GetComponent<Destructible>();
        destructible.CurrentArmor = Mathf.Clamp(destructible.CurrentArmor + ArmorDelta, 0, destructible.MaxArmor);
    }

    private void updateEnergy(Component other)
    {
        var w = other.GetComponentInChildren<PlayerWeapon>();
        if (!w) return;

        w.CurrentEnergy = Mathf.Clamp(w.CurrentEnergy + EnergyDelta, 0, w.MaxEnergy);
    }

    private void updateScore(Component other)
    {
        var score = other.GetComponent<ScoreCounter>();
        score.Score = Mathf.Max(0, PointsDelta);
    }

    private bool isPlayer(Component other)
    {
        var destructible = other.GetComponent<Destructible>();
        if (!destructible) return false;

        return !destructible.IsDead() && destructible.IsPlayer;
    }
}