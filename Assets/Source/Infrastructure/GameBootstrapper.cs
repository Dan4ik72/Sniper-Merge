using System;
using System.Runtime.CompilerServices;
using UnityEngine;
using VContainer;

public class GameBootstrapper : MonoBehaviour, IDisposable
{
    [Inject] private MergeService _mergeService;
    [Inject] private ShootingService _shootingService;
    [Inject] private InputService _inputService;

    private void Start()
    {
        _mergeService.Init();
        _shootingService.Init();
        _inputService.Init();
    }

    private void Update()
    {
        _mergeService.Update();
        _shootingService.Update(Time.deltaTime);
        _inputService.Update();
    }
    
    public void Dispose()
    {
        _mergeService.Disable();
        _shootingService.Disable();
        _inputService.Disable();
    }
}
