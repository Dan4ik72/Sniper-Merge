using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EndLevelService
{
    private CheckingEndLevel _checkingEndLevel;
    private LevelWalletService _levelWalletService;
    private PlayerMoneyService _playerMoneyService;

    public event Action Won;
    public event Action Lost;
    
    [Inject]
    internal EndLevelService(CheckingEndLevel checkingEndLevel, LevelWalletService levelWalletService, PlayerMoneyService playerMoneyService )
    {
        _checkingEndLevel = checkingEndLevel;
        _levelWalletService = levelWalletService;
        _playerMoneyService = playerMoneyService;
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
        
        Won?.Invoke();
    }
}
