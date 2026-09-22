using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;

    [SerializeField] private float _speed;

    private void Update()
    {
        Vector3 diractrion = new Vector3(_inputReader.InputHorizontalDiraction(), 0f, _inputReader.InputVerticalDiraction());

        transform.Translate(_speed * Time.deltaTime * diractrion);
    }
}
