using UnityEngine;
using UnityEngine.UI;
using VContainer;
using YG;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class MainMenuBasicOverlayPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private UpdatableTextView _playerMoneyText;
    //[SerializeField] private UpdatableTextView _playerGemsText;
    [SerializeField] private Button _rewardedButton;

    private PlayerMoneyService _playerMoneyService;
    
    private Canvas _canvas;

    [Inject]
    public void Construct(PlayerMoneyService playerMoneyService) => _playerMoneyService = playerMoneyService;

    public void Init()
    {
        OnMoneyValueChanged(_playerMoneyService.MoneyCount);
        
        _playerMoneyService.MoneyReceived += OnMoneyValueChanged;
        _playerMoneyService.MoneySpent += OnMoneyValueChanged;
        _rewardedButton.onClick.AddListener(OnRewardedButtonClick);
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
        //_playerGemsText.UpdateText(_playerMoneyService.GemsCount.ToString());
    }
    
    private void OnRewardedButtonClick()
    {
        Debug.Log("Reward");
        _rewardedButton.gameObject.SetActive(false);
        YandexGame.Instance._RewardedShow(0);
        AudioListener.pause = true;
        Time.timeScale = 0f;
        
        YandexGame.RewardVideoEvent += OnRewardedComplete;
    }

    private void OnRewardedComplete(int id)
    {
        YandexGame.RewardVideoEvent -= OnRewardedComplete;
        _playerMoneyService.ReceiveMoney(100);
        _rewardedButton.gameObject.SetActive(true);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}