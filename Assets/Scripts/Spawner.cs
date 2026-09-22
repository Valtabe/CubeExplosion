using System;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private int _minCubesCount;
    [SerializeField] private int _maxCubesCount;
    [SerializeField] private int _startCubes;
    [SerializeField] private float _horizontalSpawnLimitPosition;
    [SerializeField] private float _verticalSpawnLimitPositions;
    [SerializeField] private Cube _cubePrefab;


    private void Start()
    {
        float startYPosition = 2;

        for (int i = 0; i < _startCubes; i++)
        {
            var creatingCube = Instantiate(_cubePrefab);

            creatingCube.Exploded += OnExplodeCube;

            float verticalPosition = UnityEngine.Random.Range(-_verticalSpawnLimitPositions-1, _verticalSpawnLimitPositions+1);
            float horizontalPosition = UnityEngine.Random.Range(-_horizontalSpawnLimitPosition-1, _horizontalSpawnLimitPosition+1);

            creatingCube.transform.position = new Vector3 (verticalPosition, startYPosition, horizontalPosition);

        }
    }

    public List<Cube> CreateFewCubes(Cube parentCube)
    {
        List<Cube> createdCubes= new List<Cube>();
        int creatingCubesCount = UnityEngine.Random.Range(_minCubesCount, _maxCubesCount + 1);

        for (int i = 0; i < creatingCubesCount; i++)
        {
            createdCubes.Add(Create(parentCube));
        }

        return createdCubes;
    }

    private Cube Create(Cube parentCube)
    {
        int reductorFactor = 2;
        var creatingCube = Instantiate(parentCube);

        creatingCube.Exploded += OnExplodeCube;

        creatingCube.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
        creatingCube.transform.localScale = gameObject.transform.localScale * parentCube.SplitChance / reductorFactor;
        creatingCube.DecreaseSplitChance();

        return creatingCube;
    }

    private void OnExplodeCube(Cube cube)
    {
        cube.Exploded -= OnExplodeCube;
        Destroy(cube.gameObject);
        cube = null;
    }
}
