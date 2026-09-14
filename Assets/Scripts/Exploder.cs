using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;
    [SerializeField] private Splitter _splitter;
    [SerializeField] private CubeCreator _cubeCreator;

    private void OnEnable()
    {
        _splitter.SplitFailed += Explode;
        _cubeCreator.CubesCreated += Explode;
    }

    private void OnDisable()
    {
        _splitter.SplitFailed -= Explode;
        _cubeCreator.CubesCreated -= Explode;
    }

    private void Explode()
    {
        foreach (Rigidbody explodebleObject in GetExplodableObject())
        {
            if (_cubeCreator.IsCreatedCube(explodebleObject))
            {
                explodebleObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);
            }
        }
         
        Destroy(gameObject);
    }

    private List<Rigidbody> GetExplodableObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Rigidbody> explodebleObject = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
                explodebleObject.Add(hit.attachedRigidbody);

        return explodebleObject;
    }
}
