using UnityEngine;
using VContainer;

public class ShopItemFactory
{
    private ShopItemView _prefab;
        
    public ShopItemFactory(ShopItemView prefab) => _prefab = prefab;
    
    public ShopItemView Create(Sprite icon, int price, Transform parent, bool isMoneyCurrency, bool isBought, bool isSelected,bool isLocked = true)
    {
        var newShopItem = Object.Instantiate(_prefab, parent);
        
        newShopItem.Construct(icon, price, isMoneyCurrency, isLocked, isBought, isSelected);
        newShopItem.transform.SetParent(parent);
        
        return newShopItem;
    }
}
