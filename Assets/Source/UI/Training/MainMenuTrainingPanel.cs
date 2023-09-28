using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class MainMenuTrainingPanel : MonoBehaviour, IUiPanel
{
    private Canvas _canvas;
    
    public void Init()
    {
        _canvas = GetComponent<Canvas>();
    }

    public void Disable()
    {
    }

    public Canvas GetCanvas() => _canvas;
}
