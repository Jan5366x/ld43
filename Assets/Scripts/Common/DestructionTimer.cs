using UnityEngine;

namespace Common
{
    public class DestructionTimer : MonoBehaviour
    {

        public float Lifetime = 1F;
        public Transform DestructionPrefab;

        private float _timer = 0F;
        
        private void Update()
        {
            _timer += Time.deltaTime;

            if (_timer >= Lifetime)
                Die();
        }
        
        public void Die()
        {
            Vector3 spawnPos = transform.position;
            
            Destroy(gameObject);
            
            if (DestructionPrefab != null)
                Instantiate(DestructionPrefab, spawnPos, Quaternion.identity);
        }
    }
}