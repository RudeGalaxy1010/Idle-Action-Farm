using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace IdleActionFarm
{
    public class Storage : MonoBehaviour, IStorage
    {
        public event UnityAction<int> StacksCountChanged;

        [SerializeField] private int _capacity = 40;
        [SerializeField] private float _throwingDelay;
        [SerializeField] private List<StackView> _stacksView;

        private int _activeStackIndex;

        public int StacksCount => _activeStackIndex + 1;
        public int Capacity => _capacity;
        public bool HasStacks => _activeStackIndex >= 0;
        public bool IsFull => _activeStackIndex == _capacity - 1;

        private void Start()
        {
            _activeStackIndex = -1;

            foreach (var stackView in _stacksView)
            {
                stackView.gameObject.SetActive(false);
            }

            StacksCountChanged?.Invoke(StacksCount);
        }

        public bool TryAddStack()
        {
            if (IsFull)
            {
                return false;
            }

            _activeStackIndex++;
            _stacksView[_activeStackIndex].gameObject.SetActive(true);
            StacksCountChanged?.Invoke(StacksCount);
            return true;
        }

        public bool TryRemoveStack()
        {
            if (HasStacks == false)
            {
                return false;
            }

            _stacksView[_activeStackIndex].gameObject.SetActive(false);
            _activeStackIndex--;
            StacksCountChanged?.Invoke(StacksCount);
            return true;
        }

        private void RemoveStack(StackView stackView)
        {
            stackView.MoveCompleted -= RemoveStack;
            stackView.gameObject.SetActive(false);
            _activeStackIndex--;
            StacksCountChanged?.Invoke(StacksCount);
        }

        public void ThrowStacks(Vector3 targetPosition)
        {
            if (HasStacks == false)
            {
                return;
            }

            StartCoroutine(ThrowStacks(targetPosition, _throwingDelay));
        }

        private IEnumerator ThrowStacks(Vector3 targetPosition, float delay)
        {
            for (int i = _activeStackIndex; i >= 0; i--)
            {
                yield return new WaitForSeconds(delay);
                Instantiate(_stacksView[i], transform.position, Quaternion.identity).Throw(targetPosition);
                RemoveStack(_stacksView[i]);
            }
        }
    }
}
