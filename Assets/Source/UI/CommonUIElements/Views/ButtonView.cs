using System;
using UnityEngine;
using UnityEngine.Events;
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
        _button ??= GetComponent<Button>(); 
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

    private void OnValidate()
    {
        /*if(_button != null)
            return;

        if (TryGetComponent(out Button button))
            _button = button;*/
    }
}