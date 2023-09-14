using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class MainMenuBasicOverlayPanel : MonoBehaviour, IUiPanel
{
    [SerializeField] private UpdatableTextView _playerMoneyText;
    
    private Canvas _canvas;
    
    public void Init()
    {
    }
    
    public void Disable()
    {
    }
    
    public Canvas GetCanvas() => _canvas;
}
