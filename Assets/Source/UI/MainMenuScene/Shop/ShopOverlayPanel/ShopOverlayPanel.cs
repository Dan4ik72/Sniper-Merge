using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class ShopOverlayPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private List<ShopPanel> _shopPanels;

    [SerializeField] private ShopPanel _defaultPanel;
    
    private Canvas _canvas;

    [Inject]
    public void Construct(DataStorageService dataStorageService, PlayerMoneyService playerMoneyService)
    {
        _canvas = GetComponent<Canvas>();

        foreach (var shopPanel in _shopPanels)
            shopPanel.Construct(dataStorageService, playerMoneyService);
    }
    
    public void Init()
    {
        foreach (var shopPanel in _shopPanels)
        {
            shopPanel.Init();

            shopPanel.PanelSwitchRequested += OnPanelSwitchRequested;
        }
        
        OnPanelSwitchRequested(_defaultPanel);
    }

    public void Disable()
    {
        foreach (var shopPanel in _shopPanels)
        {
            shopPanel.PanelSwitchRequested -= OnPanelSwitchRequested;
            shopPanel.Disable();   
        }
    }

    public Canvas GetCanvas() => _canvas;

    private void OnPanelSwitchRequested(ShopPanel target)
    {
        var panelsExcludedTarget = _shopPanels.Where(panel => panel != target).ToList();
        panelsExcludedTarget.ForEach(panel => panel.OnPanelHidden());

        target.EnablePanel();
    }
}
