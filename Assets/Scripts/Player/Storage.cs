using System.Collections.Generic;
using UnityEngine;

namespace IdleActionFarm
{
    public class Storage : MonoBehaviour
    {
        [SerializeField] private int _capacity = 40;
        [SerializeField] private List<GameObject> _stacksView;

        private int _activeStackIndex;

        private void Start()
        {
            _activeStackIndex = -1;

            foreach (var stackView in _stacksView)
            {
                stackView.gameObject.SetActive(false);
            }
        }

        public bool TryAddStack()
        {
            if (_activeStackIndex >= _capacity - 1)
            {
                return false;
            }

            _activeStackIndex++;
            _stacksView[_activeStackIndex].gameObject.SetActive(true);
            return true;
        }
    }
}
