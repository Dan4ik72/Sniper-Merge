using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class GunShopPanel : ShopPanel
{
    private const string BoughtShopItemKey = "GunBought";
    private const string SelectedShopItemKey = "GunSelected";
    
    [SerializeField] private GunShopItemsConfig _gunShopItemsConfig;
    [SerializeField] private Transform _shopItemsParent;
    
    private IReadOnlyList<GunShopItemData> _gunShopItemsData;
    
    private Dictionary<ShopItemView, GunShopItemData> _gunShopItemsInstances = new();

    public override void Init()
    {
        base.Init();

        PlayerMoneyService.MoneyReceived += UpdateButtons;
        PlayerMoneyService.MoneySpent += UpdateButtons;

        SortGunShopItemsListByGunLevel();
        CreateShopItems();  
    
        UpdateButtons();
        
        CheckSelectedGun();
        
        SelectCoolestGun();
    }
    
    public override void Disable()
    {
        base.Disable();
        
        foreach(var gunShopItem in _gunShopItemsInstances.Keys)
            gunShopItem.Disable();
    }

    protected override void OnShopItemBuyButtonClicked(ShopItemView shopItemView)
    {
        if (shopItemView.IsMoneyCurrency)
        {
            if(PlayerMoneyService.TrySpendMoney((uint)shopItemView.Price) == false)
                return;
        }
        else
        {
            if(PlayerMoneyService.TrySpendGems((uint)shopItemView.Price) == false)
                return;
        }
        
        shopItemView.SetPurchasedState(true);
        DataStorageService.SaveData<string>(BoughtShopItemKey + _gunShopItemsInstances[shopItemView].GunData.GunLevel, "true");

        shopItemView.BuyButtonClicked -= OnShopItemBuyButtonClicked;
    }

    protected override void OnShopItemSelectButtonClicked(ShopItemView shopItemView)
    {
        var gunShopItemData = _gunShopItemsInstances[shopItemView];
        
        DataStorageService.SaveData<GunData>(gunShopItemData.GunData);

        foreach (var selected in _gunShopItemsInstances)
        {
            DataStorageService.RemoveSaveData(SelectedShopItemKey + selected.Value.GunData.GunLevel);
            selected.Key.SetSelectedState(false);
        }

        shopItemView.SetSelectedState(true);
        DataStorageService.SaveData<string>(SelectedShopItemKey + _gunShopItemsInstances[shopItemView].GunData.GunLevel, "true");
    }

    private void CreateShopItems()
    {
        var currentPlayerLevel = LevelLoadService.LevelsOpened;

        foreach (var data in _gunShopItemsData)
        {
            bool isBought = DataStorageService.TryGetData(BoughtShopItemKey + data.GunData.GunLevel, out string bought);
            bool isSelected = DataStorageService.TryGetData(SelectedShopItemKey + data.GunData.GunLevel, out string selected);
            
            var created = ShopItemFactory.Create(data.GunIcon, data.Price, _shopItemsParent,
                data.IsMoneyCurrency, isBought ,isSelected,data.LevelRequired >= currentPlayerLevel);
            created.Init();
            
            _gunShopItemsInstances.Add(created, data);
            
            created.BuyButtonClicked += OnShopItemBuyButtonClicked;
            created.SelectButtonClicked += OnShopItemSelectButtonClicked;
        }
    }

    private void CheckSelectedGun()
    {
        if(PlayerPrefs.HasKey(SelectedShopItemKey))
            return;
            
        OnShopItemBuyButtonClicked(_gunShopItemsInstances.Keys.ToList()[0]);
        OnShopItemSelectButtonClicked(_gunShopItemsInstances.Keys.ToList()[0]);
    }
    
    private void SortGunShopItemsListByGunLevel() =>
        _gunShopItemsData = _gunShopItemsConfig.GunShopItems.OrderBy(gunShopItem => gunShopItem.GunData.GunLevel)
            .ToList();

    private void SelectCoolestGun()
    {
        var bought =  _gunShopItemsInstances.Where(shopItemView => shopItemView.Key.IsBought)
            .OrderByDescending(shopItemView => shopItemView.Value.Price).FirstOrDefault().Key;

        if (bought == null)
            return;
        
        OnShopItemSelectButtonClicked(bought);
    }
    
    private void UpdateButtons(int newValue = 0)
    {
        var unlockedNotBoughtForMoney = _gunShopItemsInstances.Where(keyValuePair =>
            keyValuePair.Key.IsBought == false && keyValuePair.Key.IsLocked == false && keyValuePair.Key.IsMoneyCurrency).ToList();
        
        var unlockedNotBoughtForGems = _gunShopItemsInstances.Where(keyValuePair =>
            keyValuePair.Key.IsBought == false && keyValuePair.Key.IsLocked == false && keyValuePair.Key.IsMoneyCurrency == false).ToList();

        foreach (var shopItemView in unlockedNotBoughtForMoney)
            shopItemView.Key.SetPurchaseAvailableState(PlayerMoneyService.MoneyCount >= shopItemView.Value.Price);

        foreach(var shopItemView in unlockedNotBoughtForGems)
            shopItemView.Key.SetPurchaseAvailableState(PlayerMoneyService.GemsCount >= shopItemView.Value.Price);

        
    }
}