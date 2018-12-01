using UnityEngine;

namespace Common
{
    public class SimpleMove : MonoBehaviour
    {
        public float MovementSpeed = 1F;
        private void Update()
        {
            transform.position += transform.right * Time.deltaTime * MovementSpeed;
        }
    }
}