using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splitter : MonoBehaviour
{
    [SerializeField] private CubeCreator _cubeCreator;
    [SerializeField] private Interactor _interactor;
    [SerializeField] private int SplitCounter;

    public event Action SplitFailed;
    public event Action SplitSuccessed;

    private void OnEnable()
    {
        _interactor.CubeInteracted += Split;
    }

    private void OnDisable()
    {
        _interactor.CubeInteracted -= Split;
    }

    private void Split()
    {
        if (_interactor.IsTarget(gameObject))
        {
            int maxProbability = 100;
            float splitProbability = (float)(maxProbability / Math.Pow(2, SplitCounter));
            int randomNumber = UnityEngine.Random.Range(0, maxProbability + 1);

            if (randomNumber <= splitProbability)
            {
                SplitCounter++;
                SplitSuccessed?.Invoke();
            }
            else
            {
                SplitFailed?.Invoke();
            }
        }
    }
}