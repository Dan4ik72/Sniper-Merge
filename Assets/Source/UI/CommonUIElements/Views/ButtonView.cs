using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class ButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;

    private Canvas _canvas;

    public event Action Clicked;

    public void Init()
    {
        _canvas = GetComponent<Canvas>();
        _button.onClick.AddListener(OnButtonClick);
    }

    public void SetButtonActivity(bool isActive)
    {
        _button.interactable = isActive;
    }

    public void SetButtonEnable(bool isEnable)
    {
        _canvas.enabled = isEnable;
    }

    public void Disable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick() => Clicked?.Invoke();
}