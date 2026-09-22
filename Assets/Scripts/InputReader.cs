using System;
using UnityEngine;

public class InputReader : MonoBehaviour
{
    private readonly string Horizontal = "Horizontal";
    private readonly string Vertical = "Vertical";

    public event Action MouseLeftButtonClecking;
    public event Action<float, float> DiractionInputing;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            MouseLeftButtonClecking?.Invoke();
        }

        if (Input.GetAxis(Horizontal) != 0 || Input.GetAxis(Vertical) != 0)
        {
            DiractionInputing?.Invoke(Input.GetAxis(Horizontal), Input.GetAxis(Vertical));
        }
    }
}
