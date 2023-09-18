using UnityEngine;
using VContainer;

internal class SpikeObstacleFactory : IObstacleFactory
{
    private SpikeObstacleConfig _defaultConfig;

    private DataStorageService _dataStorageService;
    
    [Inject]
    internal SpikeObstacleFactory(SpikeObstacleConfig config, DataStorageService dataStorageService)
    {
        _defaultConfig = config;
        _dataStorageService = dataStorageService;
    }

    public IObstacle Create()
    {
        var data = CreateData();
        var model = CreateModel(data);
        var view = CreateView(data);

        return new SpikeObstacle(view, model);
    }

    private SpikeObstacleModel CreateModel(SpikeObstacleData data)
    {
        return new SpikeObstacleModel(data.Damage, data.ObstacleDurability,
            data.DurabilityDecreasingStep, data.DamageTickRate);
    }

    private CollisionDetectionView CreateView(SpikeObstacleData data)
    {
        return Object.Instantiate(Resources.Load<CollisionDetectionView>(data.ViewPrefabPath), data.Position, data.Rotation);
    }

    private SpikeObstacleData CreateData()
    {
        if (_dataStorageService.TryGetData(out SpikeObstacleData data))
            return data;
                      
        var defaultData = new SpikeObstacleData
        {
            ViewPrefabPath = _defaultConfig.ViewPrefabPath,
            Position = _defaultConfig.Position,
            Rotation = _defaultConfig.Rotation,
            Damage = _defaultConfig.Damage,
            ObstacleDurability = _defaultConfig.ObstacleDurability,
            DamageTickRate = _defaultConfig.DamageTickRate,
            DurabilityDecreasingStep = _defaultConfig.DurabilityDecreasingStep
        };
        
        _dataStorageService.SaveData<SpikeObstacleData>(defaultData);

        return defaultData;
    }
}
