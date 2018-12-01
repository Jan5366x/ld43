using UnityEngine;

namespace Combat
{
    public class Destructible : MonoBehaviour
    {
        public float MaxArmor = 100F;
        public float CurrentArmor = 100F;
        public float ArmorRegeneration = 0F;
        public float MaxShield = 200F;
        public float CurrentShield = 200F;
        public float ShieldRegeneration = 0.2F;
        public Transform destructionPrefab;


        public void hit(float damage)
        {
            if (isDead())
                return;

            if (damage <= CurrentShield)
            {
                CurrentShield -= damage;
            }
            else
            {
                CurrentShield = 0;
                CurrentArmor = Mathf.Max(CurrentArmor - (damage - CurrentShield), 0);
                if (isDead())
                    die();
            }
        }

        public bool isDead()
        {
            return CurrentArmor <= 0;
        }

        public void die()
        {
            // TODO handle die and spawn destruction prefab if set
        }


    }
}