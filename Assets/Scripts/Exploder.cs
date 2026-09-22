using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void ExplodeCube(List<Cube> createdCube)
    {
        foreach (Cube explodebleObject in GetExplodableObject())
        {
            if (createdCube.Contains(explodebleObject))
            {
                explodebleObject.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, explodebleObject.transform.position, _explosionRadius);
            }
        }
    }

    private List<Cube> GetExplodableObject()
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, _explosionRadius);

        List<Cube> explodebleObject = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null)
            {
                explodebleObject.Add(hit.GetComponent<Cube>());
            }

        return explodebleObject;
    }
}
