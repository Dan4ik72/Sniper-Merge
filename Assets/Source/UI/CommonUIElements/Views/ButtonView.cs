using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonView : MonoBehaviour
{
    [SerializeField] private Button _button;

    public event Action Clicked;

    public void Init()
    {
        _button.onClick.AddListener(OnButtonClick);
    }

    public void Disable()
    {
        _button.onClick.RemoveListener(OnButtonClick);
    }

    private void OnButtonClick() => Clicked?.Invoke();
}