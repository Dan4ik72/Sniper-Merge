internal class EndLevelViewPresenter
{
    private UIGameEndingPanel _wonViewPanel;
    private UIGameEndingPanel _lostViewPanel;

    private ButtonView _mainMenuButton;

    private EndLevelViewModel _endLevelViewModel;

    internal EndLevelViewPresenter(UIGameEndingPanel wonViewPanel, UIGameEndingPanel lostViewPanel, ButtonView mainMenuButton, EndLevelViewModel endLevelViewModel)
    {
        _wonViewPanel = wonViewPanel;
        _lostViewPanel = lostViewPanel;
        _mainMenuButton = mainMenuButton;
        _endLevelViewModel = endLevelViewModel;
    }

    public void Init()
    {
        _endLevelViewModel.ShowWonGamePanel += OnGameWon;
        _endLevelViewModel.ShowLostGamePanel += OnGameLost;
    }

    public void Disable()
    {
        _endLevelViewModel.ShowWonGamePanel -= OnGameWon;
        _endLevelViewModel.ShowLostGamePanel -= OnGameLost;
    }

    private void OnGameWon()
    {
        _wonViewPanel.GetCanvas().enabled = true;
        _wonViewPanel.SetUiPanelParameters((int)_endLevelViewModel.MoneyReceived, _endLevelViewModel.EnemyKilled);
        _mainMenuButton.SetButtonEnable(true);
    }

    private void OnGameLost()
    {
        _lostViewPanel.GetCanvas().enabled = true;
        _lostViewPanel.SetUiPanelParameters((int)_endLevelViewModel.MoneyReceived, _endLevelViewModel.EnemyKilled);
        _mainMenuButton.SetButtonEnable(true);
    }
}
