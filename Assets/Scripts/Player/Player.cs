using UnityEngine;

namespace IdleActionFarm
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private Storage _storage;
        private int _score;

        public bool TryAddStack(Stack stack)
        {
            return _storage.TryAddStack();
        }
    }
}
