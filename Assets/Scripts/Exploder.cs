using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void ExplodeCube(List<Cube> createdCube)
    {
        foreach (Rigidbody explodebleObject in GetExplodableObject())
        {
            explodebleObject.TryGetComponent<Cube>(out Cube checkedCube);

            if (createdCube.Contains(checkedCube))
            {
                explodebleObject.AddExplosionForce(_explosionForce, explodebleObject.transform.position, _explosionRadius);
            }
        }
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
