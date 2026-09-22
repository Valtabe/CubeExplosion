using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    [SerializeField] private Transform _raycastPoint;
    [SerializeField] private InputReader _inputReader;

    public event Action CubeInteracted;

    private RaycastHit _hitinfo;

    private void Update()
    {
        if (_inputReader.MouseLeftButtonClicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hitinfo))
            {
                if (_hitinfo.collider.TryGetComponent<Exploder>(out Exploder exploder)) 
                    CubeInteracted?.Invoke();
            }
        }
    }

    public bool IsTarget(GameObject targetObject)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out _hitinfo))
        {
            if (_hitinfo.collider.gameObject == targetObject)
                return true;
        }

        return false;
    }
}
