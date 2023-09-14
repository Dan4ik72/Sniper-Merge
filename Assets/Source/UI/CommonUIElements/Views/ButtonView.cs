using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Canvas), typeof(GraphicRaycaster))]
public class ButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;

    [SerializeField] private TMP_Text _buttonText;
    
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

    public void SetButtonText(string text)
    {
        _buttonText.text = text;
    }

    public void Disable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick() => Clicked?.Invoke();
}