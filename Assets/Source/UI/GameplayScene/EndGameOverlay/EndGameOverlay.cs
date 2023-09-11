using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using VContainer;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class EndGameOverlay : MonoBehaviour, IUiPanel
{
    [SerializeField] private UIGameEndingPanel _gameLostGameEndingPanel;
    [SerializeField] private UIGameEndingPanel _gameWonGameEndingPanel;
    [SerializeField] private ButtonView _mainMenuButton;
    
    private Canvas _canvas;

    private EndLevelService _endLevelService;

    private EndLevelViewPresenter _endLevelViewPresenter;
    private EndLevelViewModel _endLevelViewModel;
    
    [Inject]
    public void Cosntruct(EndLevelService endLevelService)
    {
        _canvas = GetComponent<Canvas>();
    }
    
    public void Init()
    {
        _gameLostGameEndingPanel.GetCanvas().enabled = false;
        _gameWonGameEndingPanel.GetCanvas().enabled = false;
        _mainMenuButton.SetButtonActivity(false);
        
        _gameLostGameEndingPanel.Init();
        _gameWonGameEndingPanel.Init();

    }

    public void Disable()
    {
    }

    public Canvas GetCanvas() => _canvas;
}

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

    public int EnemyKilled => 3;
    public uint MoneyReceived => _levelWalletService.GetCurrentMoneyCount();

    public void Init()
    {
        _endLevelService.
    }

    public void Disable()
    {
        
    }
    
    private void OnLevelWon()
    {
        
    }

    private void OnLevelLost()
    {
        
    }
    
}

internal class EndLevelViewPresenter
{
    private UIGameEndingPanel _wonViewPanel;
    private UIGameEndingPanel _lostViewPanel;

    private ButtonView _buttonView;
    
    private EndLevelViewModel _endLevelViewModel;

    public void Init()
    {
        _endLevelViewModel.ShowWonGamePanel += OnGameLost;
        _endLevelViewModel.ShowLostGamePanel += OnGameLost;

    }
    
    private void OnGameWon()
    {
        _wonViewPanel.SetUiPanelParameters((int)_endLevelViewModel.MoneyReceived, _endLevelViewModel.EnemyKilled);
        _buttonView.SetButtonActivity(true);
    }

    private void OnGameLost()
    {
        
    }
}
