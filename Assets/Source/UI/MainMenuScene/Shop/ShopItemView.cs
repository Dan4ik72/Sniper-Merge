using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class ShopItemView : MonoBehaviour
{
    [SerializeField] private Image _icon;
    [Space]
    [SerializeField] private Image _lockImage;
    [SerializeField] private Image _lockBackground;
    [Space]
    [SerializeField] private ButtonView _buyButton;
    [SerializeField] private ButtonView _selectButton;


    public event Action<ShopItemView> BuyButtonClicked;
    public event Action<ShopItemView> SelectButtonClicked; 

    public void Construct(Sprite icon, int itemPrice, bool isMoneyCurrency, bool isLocked, bool isBought, bool isSelected)
    {
        _icon.sprite = icon;
        IsLocked = isLocked;
        IsBought = isBought;
        IsSelected = isSelected;
        Price = itemPrice;
        IsMoneyCurrency = isMoneyCurrency;
    }

    public bool IsLocked { get; private set; }
    public bool IsBought { get; private set; }
    public bool IsSelected { get; private set; }
    public int Price { get; private set; }
    public bool IsMoneyCurrency { get; private set; }

    public void Init()
    {
        _buyButton.Init();
        _selectButton.Init();
        
        _buyButton.SetButtonText(Price.ToString());
        
        SetLockedState(IsLocked);
        SetSelectedState(IsSelected);
        SetPurchasedState(IsBought);
        
        _buyButton.Clicked += OnBuyButtonClick;
        _selectButton.Clicked += OnSelectButtonClicked;
    }

    public void Disable()
    {
        _buyButton.Clicked -= OnBuyButtonClick;
        _selectButton.Clicked -= OnSelectButtonClicked;
        _buyButton.Disable();
    }

    private void SetLockedState(bool isLocked)
    {
        _lockImage.gameObject.SetActive(isLocked);
        _lockBackground.gameObject.SetActive(isLocked);
        
        _buyButton.SetButtonActivity(!isLocked);
        _selectButton.SetButtonEnable(false);
    }

    public void SetPurchasedState(bool isPurchased)
    {
        _buyButton.SetButtonEnable(!isPurchased);
        _selectButton.SetButtonEnable(isPurchased);
    }

    public void SetPurchaseUnavailableState(bool isAvailable)
    {
        _buyButton.SetButtonActivity(isAvailable);
    } 
    
    public void SetSelectedState(bool isSelected) => _selectButton.SetButtonActivity(!isSelected);

    private void OnBuyButtonClick() => BuyButtonClicked?.Invoke(this);

    private void OnSelectButtonClicked() => SelectButtonClicked?.Invoke(this);
}
