using System;
using UnityEngine;
using UnityEngine.UI;

internal class LevelView : MonoBehaviour
{
    [SerializeField] private ButtonView _button;
    [SerializeField] private  Image _lockImage;

    private int _levelIndex;
    
    public event Action<LevelView> LevelButtonClicked;

    public void Construct(int levelIndex, bool isLocked)
    {
        _levelIndex = levelIndex;
        _button.SetButtonText(levelIndex.ToString());
        SetLockState(isLocked);
    }

    public int LevelIndex => _levelIndex;
    
    public void Init()
    {
        _button.Init();
        _button.Clicked += OnButtonClick;
    }

    public void Disable()
    {
        _button.Disable();
        _button.Clicked -= OnButtonClick;  
    }

    public void SetLockState(bool isLocked)
    {
        _button.SetButtonActivity(!isLocked);
        _lockImage.gameObject.SetActive(isLocked);
    }
    
    private void OnButtonClick() => LevelButtonClicked?.Invoke(this);
}