using System;
using UnityEngine;

public class Raycaster : MonoBehaviour
{
    [SerializeField] private Transform _raycastPoint; 
    [SerializeField]private InputReader _inputReader;

    public event Action<Cube> CubeInteracted;

    
    private RaycastHit _hitinfo;

    private void Update()
    {
        if (_inputReader.MouseLeftButtonClicked)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out _hitinfo))
            {
                if (_hitinfo.collider.TryGetComponent<Cube>(out Cube cube))
                {
                    CubeInteracted?.Invoke(cube);
                }
            }
        }
    }
}
