using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;

public class GameBootstrapper : MonoBehaviour, IDisposable
{
    [Inject] private MergeService _mergeService;

    private void Start()
    {
        _mergeService.Init();
    }

    private void Update()
    {
        _mergeService.Update();
    }
    
    public void Dispose()
    {
        _mergeService.Disable();
    }
}
