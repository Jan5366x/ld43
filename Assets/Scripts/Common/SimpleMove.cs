using UnityEngine;

namespace Common
{
    public class SimpleMove : MonoBehaviour
    {
        public float MovementSpeed = 1F;
        private void Update()
        {
            transform.position += transform.forward * Time.deltaTime * MovementSpeed;
        }
    }
}