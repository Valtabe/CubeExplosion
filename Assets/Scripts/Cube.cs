using System;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _splitCounter;

    public event Action<Cube> Exploded;

    public float SplitCounter => _splitCounter;

    public void IncreaseSplitCounter() => _splitCounter++;

    public void Explode()
    {
        Exploded?.Invoke(this);
    }
}
