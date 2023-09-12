using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public abstract class ShopPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private ButtonView _panelSwitchButtonView;
    
    private Canvas _canvas;

    public event Action<ShopPanel> PanelSwitchRequested;

    public void Construct(/*DataStorageService dataStorageService*/)
    {
        _canvas = GetComponent<Canvas>();
        //DataStorageService = dataStorageService;
    }

    protected DataStorageService DataStorageService { get; private set; }
    //protected PlayerMoneyService PlayerMoneyService { get; }
    
    public void Init()
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
    
    private void OnButtonClick()
    {   
        PanelSwitchRequested?.Invoke(this);
        _panelSwitchButtonView.SetButtonActivity(false);
    }
}
