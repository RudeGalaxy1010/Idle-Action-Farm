using UnityEngine;

namespace IdleActionFarm
{
    [RequireComponent(typeof(Collider))]
    public class Stack : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player) == false)
            {
                return;
            }

            if (player.TryAddStack(this))
            {
                Destroy(gameObject);
            }
        }
    }
}
