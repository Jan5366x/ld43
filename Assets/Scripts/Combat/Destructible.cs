using System.Runtime.ConstrainedExecution;
using UnityEngine;

namespace Combat
{
    /// <summary>
    /// used for basic life and destruction logic
    /// </summary>
    public class Destructible : MonoBehaviour
    {
        public float MaxArmor = 100F;
        public float CurrentArmor = 100F;
        public float ArmorRegeneration = 0F;
        public float MaxShield = 200F;
        public float CurrentShield = 200F;
        public float ShieldRegeneration = 0.2F;
        public int Reward = 100;
        public Transform DestructionPrefab;
        public bool IsPlayer = false;

        private void Update()
        {
            // process armor regeneration
            if (CurrentArmor < MaxArmor && ArmorRegeneration > 0F)
                CurrentArmor = Mathf.Min(CurrentArmor + (ArmorRegeneration * Time.deltaTime), MaxArmor);

            // process shield regeneration
            if (CurrentShield < MaxShield && ShieldRegeneration > 0F)
                CurrentShield = Mathf.Min(CurrentShield + (ShieldRegeneration * Time.deltaTime), MaxShield);
        }

        public void hit(float damage)
        {
            if (IsDead())
                return;

            if (damage <= CurrentShield)
            {
                CurrentShield -= damage;
            }
            else
            {
                CurrentShield = 0;
                CurrentArmor = Mathf.Max(CurrentArmor - (damage - CurrentShield), 0);
                if (IsDead())
                    Die();
            }
        }

        public bool IsDead()
        {
            return CurrentArmor <= 0;
        }

        public void Die()
        {
            Vector3 spawnPos = transform.position;

           
            if (DestructionPrefab != null)
                Instantiate(DestructionPrefab, spawnPos, Quaternion.identity);

            if (!IsPlayer)
            {
                var player = GameObject.FindGameObjectWithTag("Player");
                if (player)
                {
                    var score = player.GetComponent<ScoreCounter>();
                    score.Score = Mathf.Max(0, score.Score + Reward);
                }
                Destroy(gameObject);
            }
            else
            {
                var deathpanel = GameObject.FindGameObjectWithTag("DeathPanel");
                deathpanel.GetComponent<DeathScene>().Toggle();
                gameObject.SetActive(false);
            }
        }

        public void HealArmor(float value)
        {
            if (value <= 0F)
                return;

            CurrentArmor = Mathf.Min(CurrentArmor + value, MaxArmor);
        }

        public void HealShield(float value)
        {
            if (value <= 0F)
                return;

            CurrentShield = Mathf.Min(CurrentShield + value, MaxShield);
        }

        public void RestoreShield()
        {
            CurrentShield = MaxShield;
        }

        public void RestoreArmor()
        {
            CurrentArmor = MaxArmor;
        }

        public void RestoreAll()
        {
            RestoreArmor();
            RestoreShield();
        }
    }
}