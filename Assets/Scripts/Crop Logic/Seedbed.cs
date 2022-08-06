using UnityEngine;

namespace IdleActionFarm
{
    [RequireComponent(typeof(Collider))]
    public class Seedbed : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Crop _crop;

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CutTrigger cutTrigger) && _crop.Growup)
            {
                _crop.Cut();
            }
        }
    }
}
