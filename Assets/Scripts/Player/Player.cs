using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace IdleActionFarm
{
    public class Player : MonoBehaviour
    {
        private const float CutTriggerDelay = 0.35f;
        private const float CutTriggerActiveTime = 0.65f;

        public event UnityAction<int> MoneyChanged;

        [SerializeField] private Storage _storage;
        [SerializeField] private CutTrigger _cutTrigger;
        [SerializeField] private Button _cutButton;
        [SerializeField] private Animator _animator;

        private int _money;

        public IStorage Storage => _storage;

        private void OnEnable()
        {
            _cutButton.onClick.AddListener(Cut);
        }

        private void OnDisable()
        {
            _cutButton.onClick.RemoveListener(Cut);
        }

        private void Start()
        {
            MoneyChanged?.Invoke(_money);
        }

        public void AddMoney(int value)
        {
            _money += value;
            MoneyChanged?.Invoke(_money);
        }

        private void Cut()
        {
            _animator.SetTrigger(PlayerAnimatorConstants.CutAnimation);
            StartCoroutine(ActivateCutTrigger(CutTriggerDelay, CutTriggerActiveTime));
        }

        private IEnumerator ActivateCutTrigger(float delay, float time)
        {
            yield return new WaitForSeconds(delay);
            _cutTrigger.gameObject.SetActive(true);
            yield return new WaitForSeconds(time);
            _cutTrigger.gameObject.SetActive(false);
        }
    }
}
