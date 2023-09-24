using System;

internal class EndLevelViewModel
{
    private EndLevelService _endLevelService;

    public event Action ShowLostGamePanel;
    public event Action ShowWonGamePanel;

    public EndLevelViewModel(EndLevelService endLevelService)
    {
        _endLevelService = endLevelService;
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
        //SceneManager.LoadScene(MainScene);
    }

    private void OnLevelWon() => ShowWonGamePanel?.Invoke();

    private void OnLevelLost() => ShowLostGamePanel?.Invoke();
}
