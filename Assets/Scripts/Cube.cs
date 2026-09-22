using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private float _splitChance;

    public event Action<Cube> Exploded;

    public float SplitChance => _splitChance;

    public void DecreaseSplitChance() => _splitChance /= 2;

    public void Explode()
    {
        Exploded?.Invoke(this);
    }
}
