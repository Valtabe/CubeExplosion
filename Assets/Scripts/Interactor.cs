using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class Interactor : MonoBehaviour
{
    private readonly KeyCode _activateButton = KeyCode.Mouse0;

    [SerializeField] private Transform _raycastPoint;
    public event Action CubeInteract;

    private RaycastHit _hitinfo;

    void Update()
    {
        if (_hitinfo.transform == null)
            return;

        if (_hitinfo.transform.GetComponent<Cube>() == null)
            return;

        if (Input.GetKeyDown(_activateButton))
            CubeInteract?.Invoke();

    }
}
