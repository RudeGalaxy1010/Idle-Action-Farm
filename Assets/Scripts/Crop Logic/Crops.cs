using UnityEngine;

public class Crops : MonoBehaviour
{
    [SerializeField] private Crop[] _crops;

    private void Update()
    {
        foreach (var crop in _crops)
        {
            crop.Grow(Time.deltaTime);
        }
    }
}
