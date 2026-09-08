using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class Cube : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public float SplitProbability {get; private set; }
    public float Scale { get; private set; }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    private void Explode()
    {
        foreach (Rigidbody explodebleObject in GetExplodableObject())
            explodebleObject.AddExplosionForce(_explosionForce, transform.position, _explosionRadius);

        Destroy();
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
