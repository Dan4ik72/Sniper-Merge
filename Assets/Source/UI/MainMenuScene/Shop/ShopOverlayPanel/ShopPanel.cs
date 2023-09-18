using System;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public abstract class ShopPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private ButtonView _panelSwitchButtonView;
    [SerializeField] private ShopItemView _shopItemPrefab;

    private Canvas _canvas;
    
    public event Action<ShopPanel> PanelSwitchRequested;

    public void Construct(DataStorageService dataStorageService, PlayerMoneyService playerMoneyService)
    {
        _canvas = GetComponent<Canvas>();
        ShopItemFactory = new ShopItemFactory(_shopItemPrefab);
        PlayerMoneyService = playerMoneyService;
        DataStorageService = dataStorageService;
    }

    protected DataStorageService DataStorageService { get; private set; }
    protected ShopItemFactory ShopItemFactory { get; private set; }
    protected PlayerMoneyService PlayerMoneyService { get; private set; }

    public virtual void Init()
    {
        _panelSwitchButtonView.Init();
        _panelSwitchButtonView.Clicked += OnButtonClick;
    }

    public virtual void Disable()
    {
        _panelSwitchButtonView.Clicked -= OnButtonClick;
    }
    
    public Canvas GetCanvas() => _canvas;

    public virtual void OnPanelHidden()
    {
        _canvas.enabled = false;
        _panelSwitchButtonView.SetButtonActivity(true);
    }

    public virtual void EnablePanel()
    {
        _canvas.enabled = true;
        _panelSwitchButtonView.SetButtonActivity(false);
    }

    protected abstract void OnShopItemBuyButtonClicked(ShopItemView shopItemView);
     
    protected abstract void OnShopItemSelectButtonClicked(ShopItemView shopItemView);
    
    private void OnButtonClick()
    {   
        PanelSwitchRequested?.Invoke(this);
        _panelSwitchButtonView.SetButtonActivity(false);
    }
}
