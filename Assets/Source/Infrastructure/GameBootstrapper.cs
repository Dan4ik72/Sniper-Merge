using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;

public class GameBootstrapper : MonoBehaviour, IDisposable
{
    [Inject] private MergeService _mergeService;
    [Inject] private ShootingService _shootingService;

    private void Start()
    {
        _mergeService.Init();
        _shootingService.Init();
    }

    private void Update()
    {
        _mergeService.Update();
        _shootingService.Update(Time.deltaTime);
    }
    
    public void Dispose()
    {
        _mergeService.Disable();
        _shootingService.Disable();
    }
}
