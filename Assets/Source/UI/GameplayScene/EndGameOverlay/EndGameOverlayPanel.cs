using UnityEngine;
using UnityEngine.UI;
using VContainer;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class EndGameOverlayPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private UIGameEndingPanel _gameLostEndingPanel;
    [SerializeField] private UIGameEndingPanel _gameWonEndingPanel;
    [SerializeField] private ButtonView _mainMenuButton;
    
    private Canvas _canvas;

    private EndLevelService _endLevelService;
    private LevelWalletService _levelWaletService;

    private EndLevelViewPresenter _endLevelViewPresenter;
    private EndLevelViewModel _endLevelViewModel;
    
    [Inject]
    public void Cosntruct(EndLevelService endLevelService, LevelWalletService levelWalletService)
    {
        _canvas = GetComponent<Canvas>();
        _endLevelService = endLevelService;
        _levelWaletService = levelWalletService;
        _endLevelViewModel = new EndLevelViewModel(_endLevelService);
        _endLevelViewPresenter = new EndLevelViewPresenter(_gameWonEndingPanel, _gameLostEndingPanel, _mainMenuButton, _endLevelViewModel);
    }
    
    public void Init()
    {
        _gameLostEndingPanel.Init();
        _gameWonEndingPanel.Init();
        _mainMenuButton.Init();
        _endLevelViewModel.Init();
        _endLevelViewPresenter.Init();

        _gameLostEndingPanel.GetCanvas().enabled = false;
        _gameWonEndingPanel.GetCanvas().enabled = false;
        _mainMenuButton.SetButtonEnable(false);
        
    }

    public void Disable()
    {
        _mainMenuButton.Disable();
        _gameLostEndingPanel.Disable();
        _gameWonEndingPanel.Disable();
        _endLevelViewModel.Disable();
        _endLevelViewPresenter.Disable();
    }

    public Canvas GetCanvas() => _canvas;
}
