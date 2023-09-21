using System;
using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using UnityEngine;
using VContainer;

public class MainMenuBootstrapper : MonoBehaviour, IDisposable
{
    [Inject] private UIBootstrapService _uiBootstrapService;
    [Inject] private PlayerMoneyService _playerMoneyService;
    [Inject] private DataStorageService _dataStorageService;
    [Inject] private LevelLoadService _levelLoadService;

    private void Start()
    {
        _playerMoneyService.Init();
        _uiBootstrapService.Init();
        _levelLoadService.Init();
    }

    private void Update()
    {
    }
    
    public void Dispose()
    {
        _uiBootstrapService.Disable();
    }
}
