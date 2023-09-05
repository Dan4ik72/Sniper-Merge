using UnityEngine;

public interface IUiPanel
{
    public void Init();

    public void Disable();
    
    public Canvas GetCanvas();
}