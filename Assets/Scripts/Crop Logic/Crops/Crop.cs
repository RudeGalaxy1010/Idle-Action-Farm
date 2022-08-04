using UnityEngine;

public abstract class Crop : MonoBehaviour
{
    [SerializeField] protected float GrowTime;

    protected float Timer;

    public bool Growup => Timer >= GrowTime;

    public abstract void Grow(float tickTime);
    public abstract void Cut();
    public abstract void ResetGrow();
}
