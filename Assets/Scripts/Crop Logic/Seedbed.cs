using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace IdleActionFarm
{
    [RequireComponent(typeof(Collider))]
    public class Seedbed : MonoBehaviour
    {
        [SerializeField] private Player _player;
        [SerializeField] private Crop _crop;
        [SerializeField] private float _interactionDistance;
        
        //private void OnMouseDown()
        //{
        //    float distanceToPlayer = Vector3.Distance(_player.transform.position, transform.position);
        //    if (distanceToPlayer <= _interactionDistance && _crop.Growup)
        //    {
        //        _crop.Cut();
        //    }
        //}

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out CutTrigger cutTrigger))
            {
                _crop.Cut();
            }
        }
    }
}
