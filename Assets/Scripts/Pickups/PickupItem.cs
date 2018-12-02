﻿using System.Collections;
using System.Collections.Generic;
using Combat;
using UnityEngine;
using UnityEngine.Serialization;

public class PickupItem : MonoBehaviour
{
    public int ShieldDelta;
    public int ShieldDeltaMax;
    public int ShieldDeltaRegen;
    public int PointsDelta;
    public int ArmorDelta;
    public int ArmorDeltaMax;
    public int ArmorDeltaRegen;
    public int EnergyDelta;
    public int EnergyDeltaMax;
    public int EnergyDeltaRegen;
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
        destructible.MaxShield = Mathf.Max(destructible.MaxShield + ShieldDeltaMax, 0);
        destructible.ShieldRegeneration = Mathf.Max(destructible.ShieldRegeneration + ShieldDeltaRegen, 0);
        destructible.CurrentShield = Mathf.Clamp(destructible.CurrentShield + ShieldDelta, 0, destructible.MaxShield);
    }

    private void updateArmor(Component other)
    {
        var destructible = other.GetComponent<Destructible>();
        destructible.MaxArmor = Mathf.Max(destructible.MaxArmor + ArmorDeltaMax, 0);
        destructible.ArmorRegeneration = Mathf.Max(destructible.ArmorRegeneration + ArmorDeltaRegen, 0);
        destructible.CurrentArmor = Mathf.Clamp(destructible.CurrentArmor + ArmorDelta, 0, destructible.MaxArmor);
    }

    private void updateEnergy(Component other)
    {
        var w = other.GetComponentInChildren<PlayerWeapon>();
        if (!w) return;

        w.MaxEnergy = Mathf.Max(w.MaxEnergy + EnergyDeltaMax, 0);
        w.EnergyRegeneration = Mathf.Max(w.EnergyRegeneration + EnergyDeltaRegen, 0);
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