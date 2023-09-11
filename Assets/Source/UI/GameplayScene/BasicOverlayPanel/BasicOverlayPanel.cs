using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using VContainer;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class BasicOverlayPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private UpdatableTextView _playerLevelMoneyView;
    [SerializeField] private UpdatableTextView _updatablePlayerHealthView;
    [SerializeField] private UpdatableTextView _defaultPlayerHealthView;
    [SerializeField] private SliderView _playerHealthSlider;
    
    private Canvas _canvas;

    private PlayerMoneyViewPresenter _playerMoneyViewPresenter;

    private PlayerHeathViewPresenter _playerHeathViewPresenter;

    [Inject]
    public void Construct(LevelWalletService levelWalletService, ShootingService shootingService)
    {
        _canvas = GetComponent<Canvas>();
        
        _playerMoneyViewPresenter = new PlayerMoneyViewPresenter(_playerLevelMoneyView, levelWalletService);

        _playerHeathViewPresenter = new PlayerHeathViewPresenter(_updatablePlayerHealthView, _defaultPlayerHealthView, _playerHealthSlider, shootingService);
    }

    public Canvas GetCanvas() => _canvas;

    public void Init()
    {
        _playerMoneyViewPresenter.Init();
        _playerHeathViewPresenter.Init();
        _playerHealthSlider.Init();
    }

    public void Disable()
    {
        _playerMoneyViewPresenter.Disable();
        _playerHeathViewPresenter.Disable();
    }
}