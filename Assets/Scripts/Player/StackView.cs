using UnityEngine;
using UnityEngine.Events;

namespace IdleActionFarm
{
    public class StackView : MonoBehaviour
    {
        public event UnityAction<StackView> MoveCompleted;

        [SerializeField] private float _movingSpeed;

        private Vector3 _targetPosition;
        private bool _isThrown;

        private void Update()
        {
            if (_isThrown == false)
            {
                return;
            }

            if (transform.position == _targetPosition)
            {
                OnCompleteThrowing();
            }

            transform.position = Vector3.MoveTowards(transform.position, _targetPosition, _movingSpeed * Time.deltaTime);
        }

        public void Throw(Vector3 position)
        {
            _targetPosition = position;
            _isThrown = true;
        }

        private void OnCompleteThrowing()
        {
            MoveCompleted?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
