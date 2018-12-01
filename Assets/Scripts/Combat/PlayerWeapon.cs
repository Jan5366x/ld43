using UnityEngine;

namespace Combat
{
    public class PlayerWeapon : MonoBehaviour
    {
        public Transform Projectile;
        public float FireRate = 0.3F;
        public float CurrentEnergy = 100F;
        public float MaxEnergy = 100F;
        public float EnergyRegeneration  = 1.5F;
        public float RequiredEnergy = 2F;
        
        private float _fireRateCounter = 0F;
        
        private void Update()
        {
            _fireRateCounter += Time.deltaTime;
            
            // process energy regeneration
            if (CurrentEnergy < MaxEnergy && EnergyRegeneration > 0F)
                CurrentEnergy = Mathf.Min(CurrentEnergy + (EnergyRegeneration * Time.deltaTime), MaxEnergy);

            // shot if conditions are ok
            if (Input.GetButton("Fire1") && _fireRateCounter >= FireRate && RequiredEnergy >= CurrentEnergy)
            {
                Fire();
                _fireRateCounter = 0F;
                CurrentEnergy -= RequiredEnergy;
            }
        }

        private void Fire()
        { 
            if (Projectile != null)
                Instantiate(Projectile, transform.position, Quaternion.identity);
        }
    }
}