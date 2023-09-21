using UnityEngine;
using UnityEngine.UI;
using VContainer;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class TabTransitionOverlay : MonoBehaviour, IUiPanel
{
    [SerializeField] private ButtonView _backToLevelSelectButtonView;
    [SerializeField] private ButtonView _transitToShopButtonView;

    private ShopOverlayPanel _shopPanel;
    private LevelSelectionPanel _levelSelectionPanel;
    
    private Canvas _canvas;

    [Inject]
    public void Construct(ShopOverlayPanel shopOverlayPanel, LevelSelectionPanel levelSelectionPanel)
    {
        _shopPanel = shopOverlayPanel;
        _levelSelectionPanel = levelSelectionPanel;
        _canvas = GetComponent<Canvas>();
    }
    
    public void Init()
    {
        _backToLevelSelectButtonView.Init();
        _transitToShopButtonView.Init();

        _transitToShopButtonView.Clicked += OnTransitToShopButtonClicked;
        _backToLevelSelectButtonView.Clicked += OnBackToLevelSelectButtonClicked;
        
        OnTransitToShopButtonClicked(); 
    }

    public void Disable()
    {
        _backToLevelSelectButtonView.Disable();
        _transitToShopButtonView.Disable();
        
        _transitToShopButtonView.Clicked -= OnTransitToShopButtonClicked;
        _backToLevelSelectButtonView.Clicked -= OnBackToLevelSelectButtonClicked;
    }

    private void OnTransitToShopButtonClicked()
    {
        SetPanelEnable(_shopPanel, true);
        SetPanelEnable(_levelSelectionPanel, false);
        _transitToShopButtonView.SetButtonEnable(false);
        _backToLevelSelectButtonView.SetButtonEnable(true);
    }

    private void OnBackToLevelSelectButtonClicked()
    {
        SetPanelEnable(_shopPanel, false);
        SetPanelEnable(_levelSelectionPanel, true);
        _transitToShopButtonView.SetButtonEnable(true);
        _backToLevelSelectButtonView.SetButtonEnable(false);
    }
    
    private void SetPanelEnable(IUiPanel panel, bool isEnable) => panel.GetCanvas().enabled = isEnable;
    
    public Canvas GetCanvas() => _canvas;
}
