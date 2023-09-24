using System;
using UnityEngine;

internal class EndLevelViewModel
{
    private EndLevelService _endLevelService;
    private SceneTransitionService _sceneTransitionService;

    public event Action ShowLostGamePanel;
    public event Action ShowWonGamePanel;

    public EndLevelViewModel(EndLevelService endLevelService, SceneTransitionService sceneTransitionService)
    {
        _endLevelService = endLevelService;
        _sceneTransitionService = sceneTransitionService;
    }

    public int EnemyKilled => _endLevelService.EnemyKilledCount;
    public int MoneyReceived => _endLevelService.TotalLevelReward;

    public void Init()
    {
        _endLevelService.Lost += OnLevelLost;
        _endLevelService.Won += OnLevelWon;
    }

    public void Disable()
    {
        _endLevelService.Lost -= OnLevelLost;
        _endLevelService.Won -= OnLevelWon;
    }

    public void OnButtonClick()
    {
        _sceneTransitionService.TransitToMainMenuScene();
    }

    private void OnLevelWon() => ShowWonGamePanel?.Invoke();

    private void OnLevelLost() => ShowLostGamePanel?.Invoke();
}
