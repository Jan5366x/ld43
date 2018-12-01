using UnityEngine;

namespace DefaultNamespace
{
    public interface IPickupCollectAction
    {
        void Collect(Transform player);
    }
}