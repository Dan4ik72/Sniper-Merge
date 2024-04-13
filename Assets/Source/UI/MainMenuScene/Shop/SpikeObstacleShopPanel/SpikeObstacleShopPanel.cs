using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SpikeObstacleShopPanel : ShopPanel
{
    private const string BoughtShopItemKey = "SpikeObstacleBought";
    private const string SelectedShopItemKey = "SpikeObstacleSelected";

    [SerializeField] private SpikeObstacleConfigsContainer _spikeObstacleConfigsContainer;
    [SerializeField] private Transform _shopItemsParent;
    
    private IReadOnlyList<SpikeObstacleShopItemData> _wallObstaclesData;
    
    private Dictionary<ShopItemView, SpikeObstacleShopItemData> _shopItemsInstances = new();
    
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
        DataStorageService.SaveData<string>(BoughtShopItemKey + _shopItemsInstances[shopItemView].SpikeObstacleData.Level, "true");

        shopItemView.BuyButtonClicked -= OnShopItemBuyButtonClicked;
    }

    protected override void OnShopItemSelectButtonClicked(ShopItemView shopItemView)
    {
        var shopItemsInstance = _shopItemsInstances[shopItemView];
        
        DataStorageService.SaveData<SpikeObstacleData>(shopItemsInstance.SpikeObstacleData);

        foreach (var selected in _shopItemsInstances)
        {
            DataStorageService.RemoveSaveData(SelectedShopItemKey + selected.Value.SpikeObstacleData.Level);
            selected.Key.SetSelectedState(false);
        }

        shopItemView.SetSelectedState(true);
        DataStorageService.SaveData<string>(SelectedShopItemKey + _shopItemsInstances[shopItemView].SpikeObstacleData.Level, "true");
    }

    private void CreateShopItems()
    {
        var currentPlayerLevel = 1;

        if (DataStorageService.TryGetData("CurrentLevel", out int currentLevel))
            currentPlayerLevel = currentLevel;

        currentPlayerLevel = LevelLoadService.LevelsOpened;
        
        Debug.Log(currentPlayerLevel);
        
        foreach (var data in _wallObstaclesData)
        {
            bool isBought = DataStorageService.TryGetData(BoughtShopItemKey + data.Level, out string bought);
            bool isSelected = DataStorageService.TryGetData(SelectedShopItemKey + data.SpikeObstacleData.Level, out string selected);
            
            var created = ShopItemFactory.Create(data.Sprite, data.Price, _shopItemsParent,
                data.IsMoneyCurrency, isBought, isSelected,data.LevelRequired >= currentPlayerLevel);
            created.Init();
            
            _shopItemsInstances.Add(created, data);
            
            created.BuyButtonClicked += OnShopItemBuyButtonClicked;
            created.SelectButtonClicked += OnShopItemSelectButtonClicked;
        }
    }

    private void SortShopItemsListByLevel() =>
        _wallObstaclesData = _spikeObstacleConfigsContainer.SpikeObstacleShopItemsData.OrderBy(shopItem => shopItem.Level)
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
