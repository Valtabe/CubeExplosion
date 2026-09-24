using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private Spawner _spawner;
    [SerializeField] private Exploder _exploder;
    [SerializeField] private Raycaster _raycaster;

    private void OnEnable()
    {
        _raycaster.CubeInteracted += Split;
    }

    private void OnDisable()
    {
        _raycaster.CubeInteracted -= Split;
    }

    public void Split(Cube parentCube)
    {
        float randomNumber = UnityEngine.Random.value;

        if (randomNumber <= parentCube.SplitChance)
        {
            List<Cube> createdCubes = _spawner.CreateFewCubes(parentCube);
            _exploder.ExplodeCreatedCubes(createdCubes, parentCube);
            parentCube.Explode();
        }
        else
        {
            _exploder.ExplodeCubes(parentCube);
            parentCube.Explode();
        }

    }
}
