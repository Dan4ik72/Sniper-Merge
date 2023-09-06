using UnityEngine;
using VContainer;

[RequireComponent(typeof(Canvas))]
public class BasicOverlayPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private UpdatableTextView _playerLevelMoneyView;
    
    private Canvas _canvas;

    private BasicOverlayPresenter _basicOverlayPresenter;
    private LevelWalletService _playerMoneyModel;
    
    [Inject]
    public void Construct(LevelWalletService levelWalletService)
    {
        _canvas = GetComponent<Canvas>();
        _playerMoneyModel = levelWalletService;
        _basicOverlayPresenter = new BasicOverlayPresenter(_playerLevelMoneyView, _playerMoneyModel);
    }

    public Canvas GetCanvas() => _canvas;

    public void Init()
    {
        _basicOverlayPresenter.Init();
    }

    public void Disable()
    {
        _basicOverlayPresenter.Disable();
    }
}