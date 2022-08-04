using UnityEngine;
using DG.Tweening;

namespace IdleActionFarm
{
    [RequireComponent(typeof(Collider))]
    public class SellZone : MonoBehaviour
    {
        [SerializeField] private float _waveDuration;
        [SerializeField] private Transform _stacksPoint;

        private void Start()
        {
            Material material = GetComponent<Renderer>().material;
            var targetColor = new Color(material.color.r, material.color.g, material.color.b, 0);
            material.DOColor(targetColor, _waveDuration / 2f).From().SetEase(Ease.InOutSine).SetLoops(-1, LoopType.Yoyo);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.TryGetComponent(out Player player))
            {
                player.Storage.ThrowStacks(_stacksPoint.position);
            }
        }
    }
}
