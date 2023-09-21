using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class WallObstacleShopPanel : ShopPanel
{
    private const string BoughtShopItemKey = "WallObstacleBought";
    private const string SelectedShopItemKey = "WallObstacleSelected";

    [SerializeField] private WallObstacleConfigContainer _wallObstacleConfigs;
    [SerializeField] private Transform _shopItemsParent;
    
    private IReadOnlyList<WallObstacleShopItemData> _wallObstaclesData;
    
    private Dictionary<ShopItemView, WallObstacleShopItemData> _shopItemsInstances = new();
    
    public override void Init()
    {
        base.Init();

        PlayerMoneyService.MoneyReceived += UpdateButtons;
        PlayerMoneyService.MoneySpent += UpdateButtons;
        
        UpdateButtons();
        SortShopItemsListByLevel();
        CreateShopItems();
    }

    public override void Disable()
    {
        base.Disable();
        
        foreach(var shopItem in _shopItemsInstances.Keys)
            shopItem.Disable();
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
        DataStorageService.SaveData<string>(BoughtShopItemKey + _shopItemsInstances[shopItemView].WallObstacleData.Level, "true");

        shopItemView.BuyButtonClicked -= OnShopItemBuyButtonClicked;
    }

    protected override void OnShopItemSelectButtonClicked(ShopItemView shopItemView)
    {
        var shopItemsInstance = _shopItemsInstances[shopItemView];
        
        DataStorageService.SaveData<WallObstacleData>(shopItemsInstance.WallObstacleData);

        foreach (var selected in _shopItemsInstances)
        {
            DataStorageService.RemoveSaveData(SelectedShopItemKey + selected.Value.WallObstacleData.Level);   
            selected.Key.SetSelectedState(false);
        }

        shopItemView.SetSelectedState(true);
        DataStorageService.SaveData<string>(SelectedShopItemKey + _shopItemsInstances[shopItemView].WallObstacleData.Level, "true");
    }

    private void CreateShopItems()
    {
        var currentPlayerLevel = 1;

        if (DataStorageService.TryGetData("CurrentPlayerLevel", out int currentLevel))
            currentPlayerLevel = currentLevel;

        foreach (var data in _wallObstaclesData)
        {
            bool isBought = DataStorageService.TryGetData(BoughtShopItemKey + data.Level, out string bought);
            bool isSelected = DataStorageService.TryGetData(SelectedShopItemKey + data.WallObstacleData.Level, out string selected);
            
            var created = ShopItemFactory.Create(data.Sprite, data.Price, _shopItemsParent,
                data.IsMoneyCurrency, isBought, isSelected,data.LevelRequired >= currentPlayerLevel);
            created.Init();
            
            _shopItemsInstances.Add(created, data);
            
            created.BuyButtonClicked += OnShopItemBuyButtonClicked;
            created.SelectButtonClicked += OnShopItemSelectButtonClicked;
        }
    }

    private void SortShopItemsListByLevel() =>
        _wallObstaclesData = _wallObstacleConfigs.WallObstaclesData.OrderBy(shopItem => shopItem.Level)
            .ToList();

    private void UpdateButtons(int newValue = 0)
    {
        var unlockedNotBoughtForMoney = _shopItemsInstances.Where(keyValuePair =>
            keyValuePair.Key.IsBought == false && keyValuePair.Key.IsLocked == false && keyValuePair.Key.IsMoneyCurrency).ToList();
        
        var unlockedNotBoughtForGems = _shopItemsInstances.Where(keyValuePair =>
            keyValuePair.Key.IsBought == false && keyValuePair.Key.IsLocked == false && keyValuePair.Key.IsMoneyCurrency == false).ToList();

        foreach (var shopItemView in unlockedNotBoughtForMoney)
            shopItemView.Key.SetPurchaseAvailableState(PlayerMoneyService.MoneyCount >= shopItemView.Value.Price);

        foreach(var shopItemView in unlockedNotBoughtForGems)
            shopItemView.Key.SetPurchaseAvailableState(PlayerMoneyService.GemsCount >= shopItemView.Value.Price);
    }
}
