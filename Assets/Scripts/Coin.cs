using UnityEngine;

namespace IdleActionFarm
{
    public class Coin : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Player _player;
        private int _value;

        public void Init(Player player, int value)
        {
            _player = player;
            _value = value;
        }

        private void Update()
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position, _speed * Time.deltaTime);

            if (transform.position == _player.transform.position)
            {
                _player.AddMoney(_value);
                Destroy(gameObject);
            }
        }
    }
}
