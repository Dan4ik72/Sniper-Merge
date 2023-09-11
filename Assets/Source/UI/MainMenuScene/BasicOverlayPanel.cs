using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class BasicOverlayPanel : MonoBehaviour, IUiPanel
{
    private Canvas _canvas;
    
    public void Init()
    {
    }
    
    public void Disable()
    {
    }
    
    public Canvas GetCanvas() => _canvas;
}
