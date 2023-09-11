using System;

internal class EndLevelViewModel
{
    private EndLevelService _endLevelService;
    private LevelWalletService _levelWalletService;

    public event Action ShowLostGamePanel;
    public event Action ShowWonGamePanel;

    public EndLevelViewModel(EndLevelService endLevelService, LevelWalletService levelWalletService)
    {
        _endLevelService = endLevelService;
        _levelWalletService = levelWalletService;
    }

    public int EnemyKilled => _endLevelService.EnemyKilledCount;
    public uint MoneyReceived => _levelWalletService.GetCurrentMoneyCount();

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
