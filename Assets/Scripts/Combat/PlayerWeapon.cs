using UnityEngine;
using UnityEngine.Serialization;

namespace Combat
{
    public class PlayerWeapon : MonoBehaviour
    {
        public Transform Projectile;
        public Sprite WeaponPreview;
        public Color WeaponColor;
        
        public int ProjectileCount = 1;
        public float ProjectileAngle = 15;

        public float FireRate = 0.3F;
        public float CurrentEnergy = 100F;
        public float MaxEnergy = 100F;
        public float EnergyRegeneration = 1.5F;
        public float RequiredEnergy = 2F;

        private float _fireRateCounter = 0F;

        private void Update()
        {
            _fireRateCounter += Time.deltaTime;

            // process energy regeneration
            if (CurrentEnergy < MaxEnergy && EnergyRegeneration > 0F)
                CurrentEnergy = Mathf.Min(CurrentEnergy + (EnergyRegeneration * Time.deltaTime), MaxEnergy);

            // shot if conditions are ok
            if (Input.GetButton("Fire1") && _fireRateCounter >= FireRate && RequiredEnergy <= CurrentEnergy)
            {
                Fire();
                _fireRateCounter = 0F;
                CurrentEnergy -= RequiredEnergy;
            }
        }

        private void Fire()
        {
            if (Projectile != null)
            {
                for (int i = 0; i < ProjectileCount; i++)
                {
                    var obj = Instantiate(Projectile, transform.position, Quaternion.identity);
                    var movement = obj.gameObject.GetComponent<LinearMovement>();
                    if (movement)
                    {
                        int t;
                        if (ProjectileCount % 2 == 0)
                        {
                            if (i < ProjectileCount / 2)
                            {
                                t = (i - ProjectileCount / 2);
                            }
                            else
                            {
                                t = (i - ProjectileCount / 2) + 1;
                            }
                        }
                        else
                        {
                            t = (i - ProjectileCount / 2);
                        }

                        movement.Angle = t * ProjectileAngle;
                    }
                }
            }
        }
    }
}