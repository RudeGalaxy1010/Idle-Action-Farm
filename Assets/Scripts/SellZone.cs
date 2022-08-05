using UnityEngine;
using DG.Tweening;
using System.Collections;

namespace IdleActionFarm
{
    [RequireComponent(typeof(Collider))]
    public class SellZone : MonoBehaviour
    {
        [SerializeField] private float _waveDuration;
        [SerializeField] private Transform _stacksPoint;
        [SerializeField] private float _coinsPreThrowingDelay;
        [SerializeField] private float _coinsThrowingDelay;
        [SerializeField] private Coin _coinPrefab;

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
                GiveMoney(player);
                player.Storage.ThrowStacks(_stacksPoint.position);
            }
        }

        private void GiveMoney(Player player)
        {
            if (player.Storage.IsEmpty)
            {
                return;
            }

            int coinsCount = player.Storage.StacksCount;
            int coinValue = player.Storage.Cost / coinsCount;

            StartCoroutine(CreateMoney(player, coinsCount, coinValue));
        }

        private IEnumerator CreateMoney(Player player, int coinsCount, int coinValue)
        {
            yield return new WaitUntil(() => player.Storage.IsEmpty);
            yield return new WaitForSeconds(_coinsPreThrowingDelay);

            for (int i = 0; i < coinsCount; i++)
            {
                Coin coin = Instantiate(_coinPrefab, _stacksPoint.position, _coinPrefab.transform.rotation);
                coin.Init(player, coinValue);
                yield return new WaitForSeconds(_coinsThrowingDelay);
            }
        }
    }
}
