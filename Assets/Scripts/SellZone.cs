using UnityEngine;

namespace IdleActionFarm
{
    [RequireComponent(typeof(Collider))]
    public class SellZone : MonoBehaviour
    {
        [SerializeField] private Transform _stacksPoint;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.Storage.ThrowStacks(_stacksPoint.position);
            }
        }
    }
}
