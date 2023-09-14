using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ShopItemConfig", menuName = "Shop item config/Create new Gun config")]
internal class GunShopItemsConfig : ScriptableObject
{
    [SerializeField] private List<GunShopItemData> _gunShopItems;

    public IReadOnlyList<GunShopItemData> GunShopItems => _gunShopItems;
}

[System.Serializable]
internal class GunShopItemData
{
    [SerializeField] private Sprite _gunIcon;
    [SerializeField] private int _price;
    [SerializeField] private int _levelRequired;
    [SerializeField] private GunConfig _gunConfig;

    public Sprite GunIcon => _gunIcon;
    public int Price => _price;
    public int LevelRequired => _levelRequired;
    public GunData GunData => _gunConfig.GunData;
}