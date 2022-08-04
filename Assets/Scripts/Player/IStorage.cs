using UnityEngine;

namespace IdleActionFarm
{
    public interface IStorage
    {
        public int StacksCount { get; }
        public bool TryAddStack();
        public bool TryRemoveStack();
        public void ThrowStacks(Vector3 position);
    }
}
