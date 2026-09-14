using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCreator : MonoBehaviour
{
    [SerializeField] private Splitter _splitter;
    [SerializeField] private int _minCubesCount;
    [SerializeField] private int _maxCubesCount;

    public event Action CubesCreated;

    private List<GameObject> CreatedCubes = new List<GameObject>();

    private void OnEnable()
    {
        _splitter.SplitSuccessed += CreateFewCubes;
    }

    private void OnDisable()
    {
        _splitter.SplitSuccessed -= CreateFewCubes;
    }

    private void CreateFewCubes()
    {
        int creatingCubesCount = UnityEngine.Random.Range(_minCubesCount, _maxCubesCount + 1);

        for (int i = 0; i < creatingCubesCount; i++)
        {
            Create();
        }

        CubesCreated?.Invoke();
    }

    private void Create()
    {
        int reductorFactor = 2;
        var creatingCube = Instantiate(gameObject);
        CreatedCubes.Add(creatingCube);

        creatingCube.GetComponent<Renderer>().material.color = UnityEngine.Random.ColorHSV();
        creatingCube.transform.localScale = gameObject.transform.localScale / reductorFactor;
    }

    public bool IsCreatedCube(Rigidbody rigidbodyTargetObject)
    {
        foreach (var cube in CreatedCubes)
            if (cube.GetComponent<Rigidbody>() == rigidbodyTargetObject) return true;
        return false;
    }
}
