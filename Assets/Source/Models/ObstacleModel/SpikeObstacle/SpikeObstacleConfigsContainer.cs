using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpikeObstacleContainer", menuName = "Obstacle info/Create spike obstacle container")]
public class SpikeObstacleConfigsContainer : ScriptableObject
{
    [SerializeField] private List<SpikeObstacleShopItemData> _spikeObstacleShopItemsData;

    public IReadOnlyList<SpikeObstacleShopItemData> SpikeObstacleShopItemsData => _spikeObstacleShopItemsData;
}

[System.Serializable]
public class SpikeObstacleShopItemData
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _price;
    [SerializeField] private int _levelRequired;
    [SerializeField] private SpikeObstacleConfig _spikeObstacleConfig;
    [SerializeField] private bool _isMoneyCurrency = true;

    public int Level => _spikeObstacleConfig.Level;
    public Sprite Sprite => _sprite;
    public int Price => _price;
    public bool IsMoneyCurrency => _isMoneyCurrency;
    public int LevelRequired => _levelRequired;
    public SpikeObstacleData SpikeObstacleData => _spikeObstacleConfig.Data;
} 