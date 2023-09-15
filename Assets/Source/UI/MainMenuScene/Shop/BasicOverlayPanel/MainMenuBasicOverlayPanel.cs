using UnityEngine;
using UnityEngine.UI;
using VContainer;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class MainMenuBasicOverlayPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private UpdatableTextView _playerMoneyText;
    [SerializeField] private UpdatableTextView _playerGemsText;

    private PlayerMoneyService _playerMoneyService;
    
    private Canvas _canvas;

    [Inject]
    public void Construct(PlayerMoneyService playerMoneyService) => _playerMoneyService = playerMoneyService;

    public void Init()
    {
        OnMoneyValueChanged(_playerMoneyService.MoneyCount);
        
        _playerMoneyService.MoneyReceived += OnMoneyValueChanged;
        _playerMoneyService.MoneySpent += OnMoneyValueChanged;
    }

    public void Disable()
    {
        _playerMoneyService.MoneyReceived -= OnMoneyValueChanged;
        _playerMoneyService.MoneySpent -= OnMoneyValueChanged;
    }

    public Canvas GetCanvas() => _canvas;

    private void OnMoneyValueChanged(int newValue)
    {
        _playerMoneyText.UpdateText(_playerMoneyService.MoneyCount.ToString());
        _playerGemsText.UpdateText(_playerMoneyService.GemsCount.ToString());
    }
}