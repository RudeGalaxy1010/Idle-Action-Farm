using System.Collections.Generic;
using UnityEngine;

public class Wheat : Crop
{
    [SerializeField] private Vector3 _startScale;
    [SerializeField] private GameObject[] _parts;
    [SerializeField] private Color _startColor;
    [SerializeField] private Color _endColor;

    private List<Material> _partsMaterials;

    private void Start()
    {
        _partsMaterials = new List<Material>();

        foreach (var part in _parts)
        {
            _partsMaterials.Add(part.GetComponent<Renderer>().material);
        }

        ResetGrow();
    }

    public override void Grow(float tickTime)
    {
        Timer += tickTime;
        transform.localScale = Vector3.MoveTowards(transform.localScale, Vector3.one, tickTime / GrowTime);

        foreach (var material in _partsMaterials)
        {
            float r = Mathf.MoveTowards(material.color.r, _endColor.r, tickTime / GrowTime);
            float g = Mathf.MoveTowards(material.color.g, _endColor.g, tickTime / GrowTime);
            float b = Mathf.MoveTowards(material.color.b, _endColor.b, tickTime / GrowTime);

            material.color = new Color(r, g, b);
        }
    }

    public override void Cut()
    {
        throw new System.NotImplementedException();
    }

    public override void ResetGrow()
    {
        transform.localScale = _startScale;
        Timer = 0;

        foreach (var material in _partsMaterials)
        {
            material.color = _startColor;
        }
    }
}
