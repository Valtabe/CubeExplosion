using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Cube : MonoBehaviour
{
    [SerializeField] private int _splitCounter;

    public event Action<Cube> Explode;

    public float SplitCounter => _splitCounter;

    public void IncreaseSplitCounter() => _splitCounter++;

    public void Destroy()
    {
        Explode?.Invoke(this);
    }
}
