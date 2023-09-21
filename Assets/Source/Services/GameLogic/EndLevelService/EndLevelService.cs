using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

public class EndLevelService
{
    private CheckingEndLevel _checkingEndLevel;

    public event Action Won;
    public event Action Lost;
    
    [Inject]
    internal EndLevelService(CheckingEndLevel checkingEndLevel)
    {
        _checkingEndLevel = checkingEndLevel;
    }

    public int EnemyKilledCount => _checkingEndLevel.EnemyKilledCount;
    
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

    private void OnGameLost() => Lost?.Invoke();
    
    private void OnGameWon() => Won?.Invoke();
}
