using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private readonly KeyCode _activateButton = KeyCode.Mouse0;

    [SerializeField] private Transform _raycastPoint;

    public event Action CubeInteracted;

    private RaycastHit _hitinfo;

    private void Update()
    {
        if (Input.GetKeyDown(_activateButton))
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
