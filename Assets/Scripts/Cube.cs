using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;

    public event Action<Cube> Exploded;

    private int _divider = 2;

    public float SplitChance => _splitChance;

    public void DecreaseSplitChance() => _splitChance /= _divider;

    public void Explode()
    {
        Exploded?.Invoke(this);
    }
}
