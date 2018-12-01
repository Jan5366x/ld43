using UnityEngine;

namespace Combat
{
    public class ImpactDamage : MonoBehaviour
    {
        public bool DamagePlayer = false;
        public float Damage = 10F;
        public Transform ImpactPrefab;

        private void OnTriggerEnter2D(Collider2D other)
        {
            Destructible otherUnit = other.GetComponent<Destructible>();
            
            // ignore invalid units
            if (otherUnit == null || (otherUnit.IsPlayer && !DamagePlayer) || otherUnit.IsDead())
                return;
            
            otherUnit.hit(Damage);
            
            Die();
        }
        
        public void Die()
        {
            Vector3 spawnPos = transform.position;
            
            Destroy(gameObject);
            
            if (ImpactPrefab != null)
                Instantiate(ImpactPrefab, spawnPos, Quaternion.identity);
        }
    }
}