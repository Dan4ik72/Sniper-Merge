using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EndLevelService
{
    private CheckingEndLevel _checkingEndLevel;
    private PlayerMoneyService _playerMoneyService;
    private LevelLoadService _levelLoadService;

    public event Action Won;
    public event Action Lost;
    
    [Inject]
    internal EndLevelService(CheckingEndLevel checkingEndLevel, PlayerMoneyService playerMoneyService, LevelLoadService levelLoadService)
    {
        _checkingEndLevel = checkingEndLevel;
        _playerMoneyService = playerMoneyService;
        _levelLoadService = levelLoadService;
    }

    public int EnemyKilledCount => _checkingEndLevel.EnemyKilledCount;
    public int TotalLevelReward { get; private set; }
    
    public void Init(IReadOnlyList<IDamageble> enemies, IDamageble gun, LevelConfig levelConfig)
    {
        _checkingEndLevel.Init(enemies, gun, levelConfig);
        
        _checkingEndLevel.Lost += OnGameLost;
        _checkingEndLevel.Victory += OnGameWon;
    }

    public void Disable()
    {
        _checkingEndLevel.Disable();
        _checkingEndLevel.Lost -= OnGameLost;
        _checkingEndLevel.Victory -= OnGameWon;
    }

    private void OnGameLost()
    {
        _playerMoneyService.ReceiveMoney(_checkingEndLevel.TotalReward);
        TotalLevelReward = _checkingEndLevel.TotalReward;
        
        Lost?.Invoke();
    }

    private void OnGameWon()
    {
        _playerMoneyService.ReceiveMoney(_checkingEndLevel.TotalReward);
        TotalLevelReward = _checkingEndLevel.TotalReward;
        
        _levelLoadService.IncrementOpenedLevels();
        
        Won?.Invoke();
    }
}
