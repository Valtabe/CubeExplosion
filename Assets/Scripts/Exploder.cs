using System.Collections.Generic;
using UnityEngine;

public class Exploder : MonoBehaviour
{
    [SerializeField] private float _explosionRadius;
    [SerializeField] private float _explosionForce;

    public void ExplodeCreatedCubes(List<Cube> createdCube, Cube parentCube)
    {
        foreach (Cube cube in createdCube)
        {
            cube.GetComponent<Rigidbody>().AddExplosionForce(_explosionForce, parentCube.transform.position, _explosionRadius);
        }
    }

    public void ExplodeCubes(Cube parentCube)
    {
        float cubeExplosionRadius = _explosionRadius / parentCube.SplitChance; 
        List<Cube> explodebleCubes = GetExplodableCubes(cubeExplosionRadius);

        foreach (Cube cube in explodebleCubes)
        {
            float cubeCurrentForce = _explosionForce * (1f - Mathf.Clamp01(Vector3.Distance(cube.transform.position, parentCube.transform.position) / cubeExplosionRadius)) / parentCube.SplitChance;
            cube.GetComponent<Rigidbody>().AddExplosionForce(cubeCurrentForce, parentCube.transform.position, cubeExplosionRadius);
        }
    }

    private List<Cube> GetExplodableCubes(float radius)
    {
        Collider[] hits = Physics.OverlapSphere(transform.position, radius);

        List<Cube> explodebleObject = new();

        foreach (Collider hit in hits)
            if (hit.attachedRigidbody != null && hit.TryGetComponent(out Cube cube))
            {
                explodebleObject.Add(cube);
            }

        return explodebleObject;
    }
}
