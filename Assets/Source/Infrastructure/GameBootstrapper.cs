using System;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

public class GameBootstrapper : MonoBehaviour, IDisposable
{
    [Inject] private MergeService _mergeService;
    [Inject] private ShootingService _shootingService;
    [Inject] private EnemiesService _enemiesService;
    [Inject] private InputService _inputService;
    [Inject] private MergeItemDragService _mergeItemDragService;
    [Inject] private BulletSpawnService _bulletSpawnService;
    [Inject] private EndLevelService _endLevelService;   
    [Inject] private ObstacleSpawnService _obstacleSpawnService;
    [Inject] private DataStorageService _dataStorageService;
    [Inject] private LevelWalletService _levelWalletService;
    [Inject] private GameSceneUIBootstrapService _gameSceneUIBootstrapService;
    [Inject] private UIPanelTransitService _uiPanelTransitService;

    private void Start()
    {   
        _inputService.Init();
        _mergeItemDragService.Init();
        _mergeService.Init();
        _bulletSpawnService.Init();
        _shootingService.Init(_enemiesService.Enemies);
        _enemiesService.Init(_shootingService.Gun);
        _endLevelService.Init(_enemiesService.Enemies, _shootingService.Gun);
        _obstacleSpawnService.Init();
        _gameSceneUIBootstrapService.Init();
        
        SubscribeEvents();
    }
    
    private void SubscribeEvents()
    {
        //subscribe shooting service enemy died event to LevelWalletService (receiving money)
    }

    private void UnsubscribeEvents()
    {
    }
    
    private void Update()
    {
        _mergeItemDragService.Update();
        _shootingService.Update(Time.deltaTime);
        _enemiesService.Update(Time.deltaTime);
        _inputService.Update();
    }

    public void Dispose()
    {
        _mergeItemDragService.Disable();
        _shootingService.Disable();
        _inputService.Disable();
        _obstacleSpawnService.Disable();
        _gameSceneUIBootstrapService.Disable();
        
        UnsubscribeEvents();
    }
}