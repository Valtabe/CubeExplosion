using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private CubeCreator _cubeCreator;
    [SerializeField] private Interactor _interactor;
    [SerializeField] private Cube _cube;

    public event Action SplitFailed;
    public event Action SplitSuccessed;

    private void OnEnable()
    {
        _interactor.CubeInteract += Split;
    }

    private void OnDisable()
    {
        _interactor.CubeInteract -= Split;
    }

    private void Split()
    {

    }
}
