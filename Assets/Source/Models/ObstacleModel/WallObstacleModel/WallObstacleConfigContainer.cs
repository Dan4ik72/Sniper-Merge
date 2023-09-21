using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

[CreateAssetMenu(fileName = "ObstacleContainer", menuName = "Obstacle info/Create wall obstacle container")]
public class WallObstacleConfigContainer : ScriptableObject
{
    [SerializeField] private List<WallObstacleShopItemData> _wallObstaclesData;
    
    public IReadOnlyList<WallObstacleShopItemData> WallObstaclesData => _wallObstaclesData;
}

[System.Serializable]
public class WallObstacleShopItemData
{
    [SerializeField] private Sprite _sprite;
    [SerializeField] private int _price;
    [SerializeField] private int _levelRequired;
    [SerializeField] private WallObstacleConfig _wallObstacleConfig;
    [SerializeField] private bool _isMoneyCurrency = true;

    public int Level => _wallObstacleConfig.Level;
    public Sprite Sprite => _sprite;
    public int Price => _price;
    public bool IsMoneyCurrency => _isMoneyCurrency;
    public int LevelRequired => _levelRequired;
    public WallObstacleData WallObstacleData => _wallObstacleConfig.Data;
}
