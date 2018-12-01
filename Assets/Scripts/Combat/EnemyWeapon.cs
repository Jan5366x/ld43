using UnityEngine;

namespace Combat
{
    public class EnemyWeapon : MonoBehaviour
    {
        public Transform Projectile;
        public float FireRate = 0.3F;

        private float _fireRateCounter = 0F;
        
        private void Update()
        {
            _fireRateCounter += Time.deltaTime;

            if (_fireRateCounter >= FireRate)
            {
                Fire();
                _fireRateCounter = 0F;
            }
        }

        private void Fire()
        { 
            if (Projectile != null)
                Instantiate(Projectile, transform.position, Quaternion.identity);
        }
    }
}