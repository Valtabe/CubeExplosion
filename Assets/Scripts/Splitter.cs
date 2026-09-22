using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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
        float maxProbability = 100;
        float splitProbability = (float)(maxProbability / Math.Pow(2, parentCube.SplitCounter-1));
        float randomNumber = UnityEngine.Random.value * maxProbability;

        if (randomNumber <= splitProbability)
        {
            
            List<Cube> createdCubes = _spawner.CreateFewCubes(parentCube);
            _exploder.ExplodeCube(createdCubes);
            parentCube.Destroy();
        }
        else
        {
            parentCube.Destroy();
        }

    }
}
