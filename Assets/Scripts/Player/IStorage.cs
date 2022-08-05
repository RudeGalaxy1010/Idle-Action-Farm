using UnityEngine;

namespace IdleActionFarm
{
    public interface IStorage
    {
        public int StacksCount { get; }
        public int Capacity { get; }
        public bool HasStacks { get; }
        public bool IsFull { get; }
        public bool IsEmpty { get; }
        public int Cost { get; }

        public bool TryAddStack();
        public bool TryRemoveStack();
        public void ThrowStacks(Vector3 position);
    }
}
