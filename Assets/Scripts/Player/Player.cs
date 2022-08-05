using UnityEngine;
using UnityEngine.Events;

namespace IdleActionFarm
{
    public class Player : MonoBehaviour
    {
        public event UnityAction<int> MoneyChanged;

        [SerializeField] private Storage _storage;

        private int _money;

        public IStorage Storage => _storage;

        private void Start()
        {
            MoneyChanged?.Invoke(_money);
        }

        public void AddMoney(int value)
        {
            _money += value;
            MoneyChanged?.Invoke(_money);
        }
    }
}
