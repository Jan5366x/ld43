using UnityEngine;

namespace Common
{
    public class SimpleMove : MonoBehaviour
    {
        public float MovementSpeed = 1F; // use negative value for other direction
        private void Update()
        {
            transform.position += transform.right * Time.deltaTime * MovementSpeed;
        }
    }
}